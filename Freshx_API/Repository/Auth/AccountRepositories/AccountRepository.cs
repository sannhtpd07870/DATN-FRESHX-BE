using Freshx_API.Dtos.Auth.Account;
using Freshx_API.Interfaces.Auth;
using Freshx_API.Models;
using Microsoft.AspNetCore.Identity;

namespace Freshx_API.Repository.Auth.AccountRepositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenRepository _tokenRepository;
        public AccountRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenRepository = tokenRepository;
        }
        public async Task<AppUser?> RegisterAccount(AddingRegister registerDto)
        {
            var appUser = new AppUser()
            {
                Email = registerDto.Email,
                UserName = registerDto.Email,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            //phuong thuc tao tai khoan mac dinh trong asp.netcore identity voi UseName la duy nhat neu trung lap se tao tai khoan khong thanh cong
            //vi co che modelBinding nen email va mat khau da duoc kiem tra tinh hop le truoc
            var result = await _userManager.CreateAsync(appUser, registerDto.Password);
            if (!result.Succeeded)
            {
                return null;
            }
            await _userManager.AddToRoleAsync(appUser,"Normal User");          
            return appUser;
        }
        public async Task<LoginResponse> LoginAccount(LoginRequest loginRequest)
        {
            var appUser = await _userManager.FindByEmailAsync(loginRequest.Email);
            //Tim user
            if(appUser == null)
            {
                return new LoginResponse
                {
                    Succeeded = false,
                    Message = "Email or password is invalid"
                };
            }
            // Kiem tra tai khoan co dang bi khoa hay khong
            if(await _userManager.IsLockedOutAsync(appUser))
            {
                var lockoutEnd = await _userManager.GetLockoutEndDateAsync(appUser);
                var timeRemaining = lockoutEnd.HasValue ? (int)(lockoutEnd.Value - DateTimeOffset.UtcNow).TotalSeconds : 0;
                return new LoginResponse
                {
                    Succeeded = false,
                    IsLockedOut = true,
                    Message = $"Your account is lockingout. Let's try it {timeRemaining} sesonds later",
                    LockoutTimeRemaining = timeRemaining
                };
            }
            // 4. Kiểm tra tài khoản có đang active không
            if (appUser.IsActive == false)
            {
                return new LoginResponse
                {
                    Succeeded = false,
                    IsNotAllowed = true,
                    Message = "Account is inactive"
                };
            }
            // 5. Check password và xử lý đăng nhập
            var result = await _signInManager.CheckPasswordSignInAsync(appUser,loginRequest.Password,true);
            if(result.Succeeded)
            {
                await _userManager.ResetAccessFailedCountAsync(appUser);
                // Reset LockoutEnd to null
                appUser.LockoutEnd = null;
                await _userManager.UpdateAsync(appUser);
                var tokenInfo = await _tokenRepository.IssueAccessToken(appUser);
                var refreshToken = _tokenRepository.IssueRefreshToken();
                bool checkSaveRefreshToken = await _tokenRepository.SaveRefreshToken(loginRequest.Email, refreshToken);
                var roles = await _userManager.GetRolesAsync(appUser);
                return new LoginResponse
                {
                    Succeeded = true,
                    Message = "Logined success",
                    AccessToken = tokenInfo.AccessToken,
                    ExpireAt = tokenInfo.ExpiresAt,
                    RefreshToken = refreshToken,
                    User = new UserDto
                    {
                        Email = appUser.Email,
                        CreateAt = appUser.CreatedAt,
                        UpdateAt = appUser.UpdatedAt,
                        IsActive = appUser?.IsActive ?? false,
                        Roles = (List<string>)roles
                    }
                };
            }
            var failedCount = await _userManager.GetAccessFailedCountAsync(appUser);
            if(failedCount == 0)
            {
                return new LoginResponse
                {
                    Succeeded = false,
                    Message = $"Email or password false. Your account lockedout"
                };
            }
            var attemptsLeft = 5 - failedCount;
           
            return new LoginResponse
            {
                Succeeded = false,
                Message = $"Email or password false. {attemptsLeft} remaining"
            };
        }

    }
}
