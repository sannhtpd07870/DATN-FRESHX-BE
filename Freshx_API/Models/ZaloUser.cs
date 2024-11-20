using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Freshx_API.Models;

public partial class ZaloUser
{
    [Key]
    public int? RowNumber { get; set; } // Số thứ tự hàng

    public string? Avatar { get; set; } // Đường dẫn đến ảnh đại diện

    public string UserId { get; set; } = null!; // ID người dùng

    public string? UserIdByApp { get; set; } // ID người dùng theo ứng dụng

    public string? DisplayName { get; set; } // Tên hiển thị của người dùng

    public string? Address { get; set; } // Địa chỉ của người dùng

    public string? City { get; set; } // Thành phố của người dùng

    public string? District { get; set; } // Quận của người dùng

    public string? Phone { get; set; } // Số điện thoại của người dùng

    public string? Name { get; set; } // Tên thật của người dùng
}
