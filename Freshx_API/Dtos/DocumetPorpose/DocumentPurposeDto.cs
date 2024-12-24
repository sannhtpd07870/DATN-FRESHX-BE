namespace Freshx_API.Dtos
{
    public class DocumentPurposeDto
    {
        public int DocumentPurposeId { get; set; } // ID of the document purpose
        public string? Code { get; set; }          // Code of the document purpose
        public string? Name { get; set; }          // Name of the document purpose
    }

    public class CreateDocumentPurposeDto
    {
        public string? Code { get; set; }          // Code of the document purpose
        public string? Name { get; set; }          // Name of the document purpose
    }

    public class UpdateDocumentPurposeDto
    {
        public string? Code { get; set; }          // Code of the document purpose
        public string? Name { get; set; }          // Name of the document purpose
    }
}