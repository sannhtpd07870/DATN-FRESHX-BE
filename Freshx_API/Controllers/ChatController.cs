using AutoMapper;
using Freshx_API.Dtos;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Models;
using Freshx_API.Services.Chat;
using Freshx_API.Services.CommonServices;
using Microsoft.AspNetCore.Mvc;

namespace Freshx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly ChatService _chatService;
        private readonly ILogger<ChatController> _logger;
        private readonly IMapper _mapper;
        public ChatController(ChatService chatService, ILogger<ChatController> logger, IMapper mapper)
        {
            _chatService = chatService;
            _logger = logger;
            _mapper = mapper;
        }

        // Lấy danh sách các cuộc trò chuyện
        [HttpGet("conversations")]
        public async Task<ActionResult<ApiResponse<List<ConversationDto>>>> GetConversations()
        {
            try
            {
                var conversations = await _chatService.GetConversations();
                var conversationDtos = conversations.Select(c => new ConversationDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    ExternalId = c.ExternalId,
                    CreatedAt = c.CreatedAt
                }).ToList();


                if (conversations == null || !conversations.Any())
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        ResponseFactory.Error<List<ConversationDto>>(Request.Path, "Chưa có dữ liệu nào.", StatusCodes.Status404NotFound));
                }

                return StatusCode(StatusCodes.Status200OK,
                    ResponseFactory.Success(Request.Path, conversationDtos, "Lấy dữ liệu thành công.", StatusCodes.Status200OK));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Một ngoại lệ đã xảy ra trong khi lấy danh sách các cuộc trò chuyện.");
                return StatusCode(StatusCodes.Status500InternalServerError,
        ResponseFactory.Error<object>(
            Request.Path,
            $"Một lỗi đã xảy ra: {e.Message}", // Cung cấp thông báo lỗi chi tiết hơn
            StatusCodes.Status500InternalServerError));
            }
        }

        // Lấy lịch sử tin nhắn theo ConversationId
        [HttpGet("conversations/{conversationId}/messages")]
        public async Task<ActionResult<ApiResponse<List<MessageDto>>>> GetMessages(int conversationId)
        {
            try
            {
                var messages = await _chatService.GetMessages(conversationId);

                if (messages == null || !messages.Any())
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        ResponseFactory.Error<List<MessageDto>>(Request.Path, "Không tìm thấy tin nhắn nào.", StatusCodes.Status404NotFound));
                }

                return StatusCode(StatusCodes.Status200OK,
                    ResponseFactory.Success(Request.Path, messages, "Lấy dữ liệu thành công.", StatusCodes.Status200OK));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Một ngoại lệ đã xảy ra khi lấy tin nhắn của cuộc trò chuyện ID {conversationId}.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<List<MessageDto>>(Request.Path, "Một lỗi đã xảy ra.", StatusCodes.Status500InternalServerError));
            }
        }

        // Tạo một cuộc trò chuyện mới
        [HttpPost("create_conversations")]
        public async Task<ActionResult<ApiResponse<ConversationDto>>> CreateConversation([FromBody] CreateConversationRequest request)
        {
            if (string.IsNullOrEmpty(request.Title))
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    ResponseFactory.Error<ConversationDto>(Request.Path, "Tiêu đề là bắt buộc.", StatusCodes.Status400BadRequest));
            }

            try
            {
                var conversation = await _chatService.CreateConversation(request.Title);
                
                var response = _mapper.Map<ConversationDto>(conversation);

                return StatusCode(StatusCodes.Status201Created,
                    ResponseFactory.Success(Request.Path, response, "Tạo cuộc trò chuyện thành công.", StatusCodes.Status201Created));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Một ngoại lệ đã xảy ra trong khi tạo cuộc trò chuyện.");
                return StatusCode(StatusCodes.Status500InternalServerError,
        ResponseFactory.Error<object>(
            Request.Path,
            $"Một lỗi đã xảy ra: {e.Message}", // Cung cấp thông báo lỗi chi tiết hơn
            StatusCodes.Status500InternalServerError));
            }
        }
    }


}
