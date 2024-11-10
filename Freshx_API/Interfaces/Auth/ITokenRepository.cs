using Freshx_API.Dtos.Auth.Account;
using Freshx_API.Models;

namespace Freshx_API.Interfaces.Auth
{
    public interface ITokenRepository
    {
        public Task<TokenInfo> IssueAccessToken(AppUser app);
        public string IssueRefreshToken();
        public Task<bool> SaveRefreshToken(string userName, string refreshToken);
        public Task<string?> RetrieveUsernameByRefreshToken(string refreshToken);
    }
}
