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
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? ExpiredTime { get; set; }

    }
}
