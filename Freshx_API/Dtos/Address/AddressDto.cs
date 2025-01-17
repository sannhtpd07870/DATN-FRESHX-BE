namespace Freshx_API.Dtos
{
    public class ProvinceDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class DistrictDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ProvinceCode { get; set; }
    }

    public class WardDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string DistrictCode { get; set; }
    }

    // Model classes cho kết quả tìm kiếm
    public class AddressSearchResult
    {
        public string Text { get; set; }                // Hiển thị người dùng đọc
        public AddressDetails AddressDetails { get; set; }  // Chi tiết để sử dụng trong ứng dụng
    }

    public class AddressDetails
    {
        public string WardCode { get; set; }
        public string WardName { get; set; }
        public string DistrictCode { get; set; }
        public string DistrictName { get; set; }
        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }
    }
}
