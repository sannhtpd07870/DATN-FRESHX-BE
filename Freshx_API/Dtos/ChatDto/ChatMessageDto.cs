namespace Freshx_API.Dtos
{
    public class MessageDto
    {
            public int Id { get; set; }
            public int? ConversationId { get; set; }
            public string? User { get; set; }
            public string? Message { get; set; }
            public DateTime Timestamp { get; set; }
    }
}
