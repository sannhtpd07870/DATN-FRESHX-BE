using System;
using System.Collections.Generic;

namespace convert_model.Models;

public partial class AdministrativeUnit
{
    public int AdministrativeUnitId { get; set; } // ID đơn vị hành chính

    public string? Code { get; set; } // Mã đơn vị hành chính

    public string? Name { get; set; } // Tên đơn vị hành chính

    public string? NameEnglish { get; set; } // Tên đơn vị hành chính bằng tiếng Anh

    public string? Level { get; set; } // Cấp độ đơn vị hành chính

    public int? Type { get; set; } // Loại đơn vị hành chính

    public string? DistrictCode { get; set; } // Mã quận

    public string? DistrictName { get; set; } // Tên quận

    public string? ProvinceCode { get; set; } // Mã tỉnh

    public string? ProvinceName { get; set; } // Tên tỉnh

    public int? HismappingId { get; set; } // ID bản đồ HIS

    public virtual ICollection<Employee> EmployeeDistricts { get; set; } = new List<Employee>(); // Danh sách nhân viên quận

    public virtual ICollection<Employee> EmployeeProvinces { get; set; } = new List<Employee>(); // Danh sách nhân viên tỉnh

    public virtual ICollection<Employee> EmployeeWards { get; set; } = new List<Employee>(); // Danh sách nhân viên phường/xã

    public virtual ICollection<Patient> PatientDistricts { get; set; } = new List<Patient>(); // Danh sách bệnh nhân quận

    public virtual ICollection<Patient> PatientProvinces { get; set; } = new List<Patient>(); // Danh sách bệnh nhân tỉnh

    public virtual ICollection<Patient> PatientWards { get; set; } = new List<Patient>(); // Danh sách bệnh nhân phường/xã
}
