using System;
using System.Collections.Generic;

namespace Freshx_API.Models;

public partial class DocumentPurpose
{
    public int DocumentPurposeId { get; set; } // ID mục đích tài liệu

    public string? Code { get; set; } // Mã mục đích tài liệu

    public string? Name { get; set; } // Tên mục đích tài liệu

    //public virtual ICollection<Document> Documents { get; set; } = new List<Document>(); // Danh sách tài liệu liên quan
}
