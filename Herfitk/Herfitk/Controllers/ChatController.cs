using Herfitk.API.ChatServices;
using Herfitk.API.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Herfitk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ChatService chatservice;

        public ChatController(ChatService _chatService)
        {
            chatservice = _chatService;
        }

        [HttpPost("register-user")]
        public IActionResult RegisterUser(UserChatDto user)
        {
            if (chatservice.AdduserTolist(user.Name))
            {
                return NoContent();
            }
            else
            {
                return BadRequest("This name is taken please choose another name");
            }
        }
    }
}