using System;
using System.Collections.Generic;

namespace Freshx_API.Models;

public partial class ExaminationConfirmation
{
    public int ExaminationConfirmationId { get; set; }

    public int? ReceptionId { get; set; }

    public int? MedicalExaminationId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public int? IsDeleted { get; set; }

    public virtual Invoice? MedicalExamination { get; set; }
    public Invoice Invoice { get; set; } // Thêm thuộc tính này
    public virtual Reception? Reception { get; set; }
}
