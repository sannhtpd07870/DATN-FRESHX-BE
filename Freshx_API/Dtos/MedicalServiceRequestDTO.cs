using System.ComponentModel.DataAnnotations;

public class MedicalServiceRequestDTO
{
    public int MedicalServiceRequestId { get; set; }
    public int? ServiceId { get; set; }
    public int? Quantity { get; set; }
    public decimal? ServiceUnitPrice { get; set; }
    public decimal? ServiceTotalAmount { get; set; }
    public string? Status { get; set; }
}

public class CreateMedicalServiceRequestDTO
{
    [Required]
    public int ServiceId { get; set; }
    public int Quantity { get; set; } = 1;
} 