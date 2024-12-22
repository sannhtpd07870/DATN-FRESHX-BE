namespace Freshx_API.Dtos
{
public class MedicalServiceRequestDTO
{
   public int MedicalServiceRequestId { get; set; }
   public string? RequestNumber { get; set; }
   public DateTime? RequestDate { get; set; }
   public int? ServiceId { get; set; }
   public int? Quantity { get; set; }
   public decimal? ServiceUnitPrice { get; set; }
   public decimal? ServiceTotalAmount { get; set; }
   public bool? IsApproved { get; set; }
   public bool? IsPaid { get; set; }
   public string? Status { get; set; }
   //public virtual ServiceCatalogDTO? Service { get; set; }
}
public class CreateMedicalServiceRequestDTO
{
  
   public int ReceptionId { get; set; }

   public int ServiceId { get; set; }
   public int Quantity { get; set; } = 1;
   public string? Status { get; set; }
}
public class UpdateMedicalServiceRequestDTO
{
   public int? Quantity { get; set; }
   public string? Status { get; set; }
   public bool? IsApproved { get; set; }
   public bool? IsPaid { get; set; }
}
}