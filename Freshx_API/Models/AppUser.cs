using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Freshx_API.Models
{
    public class AppUser : IdentityUser
    {
        public string? FullName { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        public bool? IsActive  { get; set; }
        public DateTime? CreatedAt { get; set; } //tạo tài khoản
        public DateTime? UpdatedAt { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? ExpiredTime { get; set; }
        public string ? Gender { get; set; }
        public string? IdentityCardNumber { get; set; } // Số CMND/CCCD
        public int? Age { get; set; }
        public int? AvatarId { get; set; }
        public int? PositionId { get; set; }
        public string? WardId { get; set; } // ID phường/xã
        public string? DistrictId { get; set; } // ID quận/huyện
        public string? ProvinceId { get; set; } // ID tỉnh/thành phố
        public virtual Ward? Ward { get; set; } // Đơn vị hành chính phường/xã
        public virtual District? District { get; set; } // Đơn vị hành chính huyện-thị trấn
        public virtual Province? Province { get; set; } // Đơn vị hành chính tỉnh
        public virtual Position? Position { get; set; }
    }
}
