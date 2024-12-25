namespace Freshx_API.Dtos
{
    public class MedicalServiceRequestDto
    {
        public int MedicalServiceRequestId { get; set; }
        public DateTime? RequestTime { get; set; }
        public int? ReceptionId { get; set; }
        public int? ServiceId { get; set; }
        public int? Quantity { get; set; }
        public decimal? ServiceTotalAmount { get; set; }
        public bool? IsApproved { get; set; }
        public bool? Status { get; set; }
        public int? AssignedById { get; set; }
        public string? AssignedByName { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }

}