using System.ComponentModel.DataAnnotations;

namespace Freshx_API.Dtos.DrugCatalog
{
    // DTO để nhận dữ liệu từ client khi tạo hoặc cập nhật danh mục thuốc
    public class DrugCatalogCreateUpdateDto
    {
        [Required(ErrorMessage = "Tên danh mục thuốc là bắt buộc.")]
        [StringLength(200, ErrorMessage = "Tên danh mục thuốc không được vượt quá 200 ký tự.")]
        public string? Name { get; set; } // Tên danh mục thuốc

        [Required(ErrorMessage = "ID đơn vị đo lường là bắt buộc.")]
        public int? UnitOfMeasureId { get; set; } // ID đơn vị đo lường

        [Required(ErrorMessage = "ID nhà sản xuất là bắt buộc.")]
        public int? ManufacturerId { get; set; } // ID nhà sản xuất

        [Required(ErrorMessage = "ID quốc gia là bắt buộc.")]
        public int? CountryId { get; set; } // ID quốc gia

        [StringLength(500, ErrorMessage = "Tên đầy đủ của thuốc không được vượt quá 500 ký tự.")]
        public string? FullName { get; set; } // Tên đầy đủ của thuốc

        [StringLength(500, ErrorMessage = "Tên không dấu của thuốc không được vượt quá 500 ký tự.")]
        public string? NameUnaccented { get; set; } // Tên không dấu của thuốc

        [StringLength(1000, ErrorMessage = "Thành phần hoạt chất không được vượt quá 1000 ký tự.")]
        public string? ActiveIngredient { get; set; } // Thành phần hoạt chất

        [StringLength(1000, ErrorMessage = "Cách sử dụng không được vượt quá 1000 ký tự.")]
        public string? Usage { get; set; } // Cách sử dụng

        [StringLength(500, ErrorMessage = "Liều lượng không được vượt quá 500 ký tự.")]
        public string? Dosage { get; set; } // Liều lượng

        [StringLength(500, ErrorMessage = "Tác dụng không được vượt quá 500 ký tự.")]
        public string? Effect { get; set; } // Tác dụng

        public int? DrugTypeId { get; set; } // ID loại thuốc

        [StringLength(500, ErrorMessage = "Phân loại thuốc không được vượt quá 500 ký tự.")]
        public string? DrugClassification { get; set; } // Phân loại thuốc

        [StringLength(500, ErrorMessage = "Đường dùng thuốc không được vượt quá 500 ký tự.")]
        public string? RouteOfAdministration { get; set; } // Đường dùng thuốc

        public int? IsSuspended { get; set; } // Trạng thái tạm ngưng

        [StringLength(50, ErrorMessage = "Mã thuốc quốc gia không được vượt quá 50 ký tự.")]
        public string? NationalDrugCode { get; set; } // Mã thuốc quốc gia

        [StringLength(2000, ErrorMessage = "Mô tả thuốc không được vượt quá 2000 ký tự.")]
        public string? Description { get; set; } // Mô tả thuốc

        [StringLength(500, ErrorMessage = "Số tham chiếu không được vượt quá 500 ký tự.")]
        public string? ReferenceNumber { get; set; } // Số tham chiếu

        [StringLength(500, ErrorMessage = "Ghi chú 1 không được vượt quá 500 ký tự.")]
        public string? Note1 { get; set; } // Ghi chú 1

        [StringLength(500, ErrorMessage = "Ghi chú 2 không được vượt quá 500 ký tự.")]
        public string? Note2 { get; set; } // Ghi chú 2

        [StringLength(500, ErrorMessage = "Ghi chú 3 không được vượt quá 500 ký tự.")]
        public string? Note3 { get; set; } // Ghi chú 3

        public int? IsDeleted { get; set; } // Trạng thái đã xóa

        [Range(0, double.MaxValue, ErrorMessage = "Số lượng nhập khẩu phải là số dương.")]
        public decimal? QuantityImported { get; set; } // Số lượng nhập khẩu

        [Range(0, double.MaxValue, ErrorMessage = "Số lượng tồn kho phải là số dương.")]
        public decimal? QuantityInStock { get; set; } // Số lượng tồn kho

        [Range(0, double.MaxValue, ErrorMessage = "Giá vốn phải là số dương.")]
        public decimal? CostPrice { get; set; } // Giá vốn

        [Range(0, double.MaxValue, ErrorMessage = "Giá bán phải là số dương.")]
        public decimal? UnitPrice { get; set; } // Giá bán
    }
}
