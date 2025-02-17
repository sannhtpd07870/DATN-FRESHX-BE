﻿using Freshx_API.Models;
using Freshx_API.Services.CommonServices.ValidationService;
using System.ComponentModel.DataAnnotations;

namespace Freshx_API.Dtos
{
    public class DoctorCreateUpdateDto
    {
        [Required(ErrorMessage = "CMND/CCCD là bắt buộc")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "CCCD phải từ 12 ký tự")]
        [RegularExpression(@"^[0-9]{12}$", ErrorMessage = "CCCD chỉ được chứa số")]
        public string? IdentityCardNumber { get; set; } // Số CMND/CCCD ktra trùng lặp

        [Required(ErrorMessage = "Tên bác sĩ là bắt buộc")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Tên phải từ 2-100 ký tự")]
        [RegularExpression(@"^[a-zA-ZÀ-ỹ\s]*$", ErrorMessage = "Tên chỉ được chứa chữ cái và khoảng trắng")]
        public string? Name { get; set; } // Tên bệnh nhân
        [Required(ErrorMessage = "Chuyên môn bác sĩ là bắt buộc")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Tên phải từ 2-100 ký tự")]
        [RegularExpression(@"^[a-zA-ZÀ-ỹ\s]*$", ErrorMessage = "Chuyên môn chỉ được chứa chữ cái và khoảng trắng")]
        public string? Specialty { get; set; }
        [Required(ErrorMessage = "Giới tính là bắt buộc")]
        [RegularExpression("^(Nam|Nữ|Khác)$", ErrorMessage = "Giới tính không hợp lệ")]
        public string? Gender { get; set; } // Giới tính 
        [Required(ErrorMessage = "Ngày sinh là bắt buộc")]
        [AgeValidation(MinAge = 0, MaxAge = 150, ErrorMessage = "Tuổi phải từ 0-150")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; } // Ngày sinh 
        [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Số điện thoại phải đúng 10 chữ số")]
        [RegularExpression(@"^(03|05|07|08|09)[0-9]{8}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string? PhoneNumber { get; set; } // Số điện thoại
        [Required(ErrorMessage = "Vai trò là bắt buộc")]
        [Range(1, int.MaxValue, ErrorMessage = "PositionID phải là số nguyên dương")]
        public int? PositionId { get; set; }
        [Required(ErrorMessage = "Phòng ban là là bắt buộc")]
        [Range(1, int.MaxValue, ErrorMessage = "DepartmentId phải là số nguyên dương")]
        public int? DepartmentId { get; set; }

        [Required(ErrorMessage = "Phường/Xã là bắt buộc")]
        public string? WardId { get; set; } // ID phường/xã

        [Required(ErrorMessage = "Quận/Huyện là bắt buộc")]
        public string? DistrictId { get; set; } // ID quận/huyện

        [Required(ErrorMessage = "Tỉnh/Thành phố là bắt buộc")]
        public string? ProvinceId { get; set; } // ID tỉnh/thành phố       
        [AvatarValidation(MaxSizeInMb = 5,
        AllowedExtensions = new[] { ".jpg", ".jpeg", ".png" },
        ErrorMessage = "File ảnh không hợp lệ")]
        public IFormFile? AvatarFile { get; set; } //Hình ảnh của bệnh nhân 
        [EmailAddress]
        [Required(ErrorMessage = "Email bắt buộc phải nhập")]
        public string? Email { get; set; }
    }
}
