using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMessageService
    {
        public  Task AddMessageAsync(MessageDTO msg);
        public  Task<MessageDTO> GetMessageByIdAsync(int id);
        public  Task<IEnumerable<MessageDTO>> GetMessagesAsync();
        public void DeleteMessage(MessageDTO Message);
    }
}
