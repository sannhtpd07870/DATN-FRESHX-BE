﻿using Freshx_API.Services.CommonServices.ValidationService;
using System.ComponentModel.DataAnnotations;

namespace Freshx_API.Dtos.Auth.Account
{
    public class ResetPasswordRequest
    {
        [StrongPassword]
        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp")]
        [Required(ErrorMessage = "Vui lòng xác nhận mật khẩu")]
        public string ConfirmPassword { get; set; }
    }
}
