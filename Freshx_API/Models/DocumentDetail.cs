using System;
using System.Collections.Generic;

namespace convert_model.Models;

public partial class DocumentDetail
{
    public int DocumentDetailId { get; set; }

    public int DocumentId { get; set; }

    public int DrugCatalogId { get; set; }

    public int? ImportLotNumberId { get; set; }

    public string? ControlNumber { get; set; }

    public string? VisaNumber { get; set; }

    public int? UnitOfMeasureId { get; set; }

    public decimal? RequestedQuantity { get; set; }

    public decimal? ActualQuantity { get; set; }

    public decimal? IssuedQuantity { get; set; }

    public string? CurrencyId { get; set; }

    public decimal? ExchangeRate { get; set; }

    public decimal? PurchasePrice { get; set; }

    public decimal? SellingPrice { get; set; }

    public decimal? CostPrice { get; set; }

    public decimal? PaymentPrice { get; set; }

    public string? BookNumber { get; set; }

    public string? VatinvoiceNumber { get; set; }

    public decimal? Vatrate { get; set; }

    public decimal? Vatamount { get; set; }

    public bool IsFree { get; set; }

    public int? FreeReasonId { get; set; }

    public string? AccountingDocumentNumber { get; set; }

    public string? CashDocumentNumber { get; set; }

    public string? Status { get; set; }

    public bool HasGeneratedIssueDocument { get; set; }

    public bool HasGeneratedReturnDocument { get; set; }

    public bool IsPromotion { get; set; }

    public int? OrderId { get; set; }

    public string? Note { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public int? SourceId { get; set; }

    public decimal? CostPriceIncludingVat { get; set; }

    public decimal? TotalPurchaseAmount { get; set; }

    public decimal? TotalCostAmount { get; set; }

    public bool? IsLotSplit { get; set; }

    public int? OriginalUnitOfMeasureId { get; set; }

    public decimal? OriginalQuantity { get; set; }

    public virtual Document Document { get; set; } = null!;

    public virtual DrugCatalog DrugCatalog { get; set; } = null!;

    public virtual UnitOfMeasure? OriginalUnitOfMeasure { get; set; }

    public virtual UnitOfMeasure? UnitOfMeasure { get; set; }
}
