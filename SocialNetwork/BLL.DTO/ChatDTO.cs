using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class ChatDTO
    {
        public int FriendshipId { get; set; }
        public ICollection<MessageDTO> Messages { get; set; }
        public ICollection<FriendshipDTO> Friendships { get; set; }
    }
}
