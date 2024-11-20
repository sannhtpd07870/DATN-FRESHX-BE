using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Freshx_API.Models;

public partial class Document
{
    [Key]
    public int DocumentId { get; set; } // ID tài liệu

    public string DocumentCode { get; set; } = null!; // Mã tài liệu

    public string DocumentNumber { get; set; } = null!; // Số tài liệu

    public DateTime DocumentDate { get; set; } // Ngày tài liệu

    public string DocumentType { get; set; } = null!; // Loại tài liệu

    public int? DocumentPurposeId { get; set; } // ID mục đích tài liệu

    public int? IssuingPharmacyId { get; set; } // ID nhà thuốc phát hành

    public int? DelivererId { get; set; } // ID người giao

    public int? ReceivingPharmacyId { get; set; } // ID nhà thuốc nhận

    public int? ReceiverId { get; set; } // ID người nhận

    public int? InspectorId { get; set; } // ID người kiểm tra

    public int? ApproverId { get; set; } // ID người phê duyệt

    public int? ChiefAccountantId { get; set; } // ID kế toán trưởng

    public int? TreasurerId { get; set; } // ID thủ quỹ

    public string? SerialNumber { get; set; } // Số serial

    public string? InvoiceNumber { get; set; } // Số hóa đơn

    public string? Description { get; set; } // Mô tả tài liệu

    public decimal? TotalValue { get; set; } // Tổng giá trị

    public decimal? PaymentValue { get; set; } // Giá trị thanh toán

    public decimal? Vatrate { get; set; } // Tỷ lệ VAT

    public decimal? Vatamount { get; set; }

    public decimal? TaxRate { get; set; }

    public decimal? TaxAmount { get; set; }

    public decimal? DiscountRate { get; set; }

    public decimal? DiscountAmount { get; set; }

    public string? CurrencyId { get; set; }

    public decimal? ExchangeRate { get; set; }

    public string? OriginalDocumentNumber { get; set; }

    public DateTime? OriginalDocumentDate { get; set; }

    public int? SupplierId { get; set; }

    public int? PaymentMethodId { get; set; }

    public int? DrugSourceId { get; set; }

    public int? RelatedDocumentId { get; set; }

    public int? MedicalExaminationId { get; set; }

    public int? InpatientPrescriptionId { get; set; }

    public int? MedicalRecordId { get; set; }

    public bool HasReceivedMedication { get; set; }

    public int? InputterId { get; set; }

    public DateTime? InputDate { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public int? RequisitionFormId { get; set; }

    public string? GeneratedTransactionDescription { get; set; } // Mô tả giao dịch được tạo

    public int? DeliveryUnitId { get; set; } // ID đơn vị giao hàng

    public decimal? ImportVatrate { get; set; } // Tỷ lệ VAT nhập khẩu

    public decimal? ImportVatamount { get; set; } // Số tiền VAT nhập khẩu

    public string? ForeignSerialNumber { get; set; } // Số serial nước ngoài

    public string? ForeignInvoiceNumber { get; set; } // Số hóa đơn nước ngoài

    public DateTime? ForeignInvoiceDate { get; set; } // Ngày hóa đơn nước ngoài

    public int? UsagePharmacyId { get; set; } // ID nhà thuốc sử dụng

    public string? MaterialTypeId { get; set; } // Mã loại vật liệu

    public int? ReferralDoctorId { get; set; } // ID bác sĩ giới thiệu

    public int? TargetObjectId { get; set; } // ID đối tượng mục tiêu

    public int? TransferId { get; set; } // ID chuyển giao

    public string? AccountingDocument { get; set; } // Tài liệu kế toán

    public int? DocumentStatus { get; set; } // Trạng thái tài liệu

    public int? TransferPaymentId { get; set; } // ID thanh toán chuyển giao

    public int? DepartmentId { get; set; } // ID phòng ban

    public int? DoctorId { get; set; } // ID bác sĩ

    public string? DebitAccount { get; set; } // Tài khoản nợ

    public string? CreditAccount { get; set; } // Tài khoản có

    public string? ReferenceDocumentCode { get; set; } // Mã tài liệu tham chiếu

    public string? ReferenceDocumentType { get; set; } // Loại tài liệu tham chiếu

    public int? DeductibleRequisitionFormId { get; set; } // ID đơn yêu cầu khấu trừ

    public int? ExecutionPharmacyId { get; set; } // ID nhà thuốc thực hiện

    public int? CorrespondingPharmacyId { get; set; } // ID nhà thuốc tương ứng

    public bool? IsHealthInsurance { get; set; } // Có bảo hiểm y tế không

    public bool? IsHospitalFee { get; set; } // Có phí bệnh viện không

    public string? FormCode { get; set; } // Mã biểu mẫu

    public int? IsDeleted { get; set; } // Trạng thái đã xóa

    public virtual Employee? Approver { get; set; } // Người phê duyệt

    public virtual Employee? ChiefAccountant { get; set; } // Kế toán trưởng

    public virtual Pharmacy? CorrespondingPharmacy { get; set; } // Nhà thuốc tương ứng

    public virtual Employee? Deliverer { get; set; } // Người giao

    public virtual Department? Department { get; set; } // Phòng ban

    public virtual Doctor? Doctor { get; set; } // Bác sĩ

    //public virtual ICollection<DocumentDetail> DocumentDetails { get; set; } = new List<DocumentDetail>(); // Danh sách chi tiết tài liệu

    public virtual DocumentPurpose? DocumentPurpose { get; set; } // Mục đích tài liệu

    public virtual Pharmacy? ExecutionPharmacy { get; set; } // Nhà thuốc thực hiện

    public virtual Employee? Inputter { get; set; } // Người nhập

    public virtual Employee? Inspector { get; set; } // Người kiểm tra

    //public virtual ICollection<Document> InverseRelatedDocument { get; set; } = new List<Document>(); // Danh sách tài liệu liên quan ngược

    public virtual Pharmacy? IssuingPharmacy { get; set; } // Nhà thuốc phát hành

    public virtual Invoice? MedicalExamination { get; set; } // Khám bệnh

    public virtual Employee? Receiver { get; set; } // Người nhận

    public virtual Pharmacy? ReceivingPharmacy { get; set; } // Nhà thuốc nhận

    public virtual Doctor? ReferralDoctor { get; set; } // Bác sĩ giới thiệu

    public virtual Document? RelatedDocument { get; set; } // Tài liệu liên quan

    public virtual Supplier? Supplier { get; set; } // Nhà cung cấp

    public virtual Employee? Treasurer { get; set; } // Thủ quỹ

    public virtual Pharmacy? UsagePharmacy { get; set; } // Nhà thuốc sử dụng
}
