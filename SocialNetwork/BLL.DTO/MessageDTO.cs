using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public UserDTO User { get; set; }
        public ChatDTO Chat { get; set; }

        public string MessageText { get; set; }
    }
}
