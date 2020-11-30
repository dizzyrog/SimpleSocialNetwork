using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Domain;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure.Services
{
    public class MessageService : BaseService, IMessageService
    {
        private readonly IUserService _userService;
        public MessageService(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService) : base(unitOfWork, mapper)
        {
            _userService = userService;
        }
        public async Task AddMessageAsync(MessageDTO msg)
        {
            var messageMapped = Mapper.Map<MessageDTO, Message>(msg);
            var user1 = await _userService.GetUserByUsernameAsync(msg.User1Username);
            messageMapped.User1Id = user1.UserIdentityId;
            var user2 = await _userService.GetUserByUsernameAsync(msg.User2Username);
            messageMapped.User2Id = user2.UserIdentityId;
            await UnitOfWork.Message.CreateAsync(messageMapped);
        }
        public async Task<MessageDTO> GetMessageByIdAsync(int id)
        {
            var result = await UnitOfWork.Message.GetByIdAsync(id);
            var resultDTO = Mapper.Map<Message, MessageDTO>(result);
            return resultDTO;
        }
        public async Task<IEnumerable<MessageDTO>> GetMessagesAsync()
        {
            var result = await UnitOfWork.Message.GetAllAsync();
            var resultDTOs = Mapper.Map<IEnumerable<Message>, IEnumerable<MessageDTO>>(result);
            return resultDTOs;
        }
        public void DeleteMessage(MessageDTO Message)
        {
            var MessageMapped = Mapper.Map<MessageDTO, Message>(Message);
            UnitOfWork.Message.Remove(MessageMapped);
        }
    }
}
