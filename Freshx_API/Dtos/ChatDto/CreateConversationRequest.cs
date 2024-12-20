using Freshx_API.Models;

namespace Freshx_API.Dtos
{
    public class CreateConversationRequest
    {
        public string Title { get; set; }
    }
    public class ConversationDto
    {
        public int Id { get; set; }
        public string? Title { get; set; } // Tên cuộc trò chuyện
        public string? ExternalId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

}
