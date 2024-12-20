using System.ComponentModel.DataAnnotations;

namespace Freshx_API.Dtos.UserAccount
{
    public class UpdatingUserRequest
    {
        public string? FullName { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; } //tạo tài khoản
        public DateTime? UpdatedAt { get; set; }
        public string? Gender { get; set; }
        public string? IdentityCardNumber { get; set; } // Số CMND/CCCD
        public int? AvatarId { get; set; }
        public int? PositionId { get; set; }
    }
}
