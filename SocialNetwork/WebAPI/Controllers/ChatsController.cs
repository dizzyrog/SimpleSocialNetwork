using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public ChatsController(IHubContext<ChatHub> hubContext, IMessageService messageService , IMapper mapper)
        {
            _hubContext = hubContext;
            _messageService = messageService;
            _mapper = mapper;
        }

        [Route("api/chat/send")]    //path looks like this: https://localhost:44379/api/chat/send
        [HttpPost]
        public async Task<IActionResult> SendRequestAsync([FromBody] MessageModel msg)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveOne", msg.User1, msg.User2, msg.MessageText);
            var messageMapped = _mapper.Map<MessageModel, MessageDTO>(msg);
            await _messageService.AddMessageAsync(messageMapped);
            return Ok();
        }
    }
}
