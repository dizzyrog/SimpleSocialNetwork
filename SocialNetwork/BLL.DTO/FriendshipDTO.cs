using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class FriendshipDTO
    {
        public UserDTO User { get; set; }
        public UserDTO Friend { get; set; }
        public ChatDTO Chat { get; set; }
    }
}
