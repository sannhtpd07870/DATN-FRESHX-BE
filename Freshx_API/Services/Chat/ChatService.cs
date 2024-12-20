using Freshx_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.Http.Headers;

namespace Freshx_API.Services.Chat
{
    public class ChatService
    {
        private readonly FreshxDBContext _context;

        public ChatService(FreshxDBContext context)
        {
            _context = context;
        }

        // Lưu tin nhắn vào database
        public async Task SaveMessage(int conversationId, string user, string message)
        {
            var chatMessage = new ChatMessage
            {
                ConversationId = conversationId,
                User = user,
                Message = message,
                Timestamp = DateTime.UtcNow
            };

            _context.ChatMessages.Add(chatMessage);
            await _context.SaveChangesAsync();
        }

        // Lấy danh sách các cuộc trò chuyện
        public async Task<List<Conversation>> GetConversations()
        {
            return await _context.Conversations
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }

        // Lấy lịch sử tin nhắn của một cuộc trò chuyện
        public async Task<List<ChatMessage>> GetMessages(int conversationId)
        {
            return await _context.ChatMessages
                .Where(m => m.ConversationId == conversationId)
                .OrderBy(m => m.Timestamp)
                .ToListAsync();
        }

        // Tạo một cuộc trò chuyện mới
        public async Task<Conversation> CreateConversation(string title)
        {

            // Định nghĩa URL và Header cho API
            var apiUrl = "https://api.coze.com/v1/conversation/create";
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "pat_uCFKVIGLosFSIIUxSo09q7AdaDAbIzxpJRQtK45v9Nnyf8W1hAEm61zQFAbNka3P");

            // Dữ liệu gửi lên API
            var requestData = new
            {
                bot_id = "7384550659657826311"
            };

            // Gửi yêu cầu POST đến API
            var response = await httpClient.PostAsJsonAsync(apiUrl, requestData);
          
            // Kiểm tra phản hồi
            if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"API call failed with status code {response.StatusCode}");
                }

                // Đọc phản hồi JSON từ API
                var responseData = await response.Content.ReadFromJsonAsync<CozeApiResponse>();
                if (responseData == null || responseData.Code != 0)
                {
                    throw new Exception($"API returned an error: {responseData?.Msg}");
                }

                // Lấy ID từ dữ liệu trả về
                var conversationId = responseData.Data.Id;

                // Lưu thông tin cuộc trò chuyện vào cơ sở dữ liệu (nếu cần thiết)
                var conversation = new Conversation
                {
                    Title = title,
                    ExternalId = conversationId.ToString(), // Lưu ID từ API trả về
                    CreatedAt = DateTime.UtcNow
                };

                _context.Conversations.Add(conversation);
                await _context.SaveChangesAsync();

                // Trả về ID của cuộc trò chuyện từ API
                return conversation;
            
           
        }

        // Lớp đại diện cho phản hồi API
        public class CozeApiResponse
        {
            public int Code { get; set; }
            public string Msg { get; set; }
            public CozeApiData Data { get; set; }
        }

        public class CozeApiData
        {
            public long Id { get; set; }
            public long CreatedAt { get; set; }
            public long LastSectionId { get; set; }
            public object MetaData { get; set; }
        }

    }

}
