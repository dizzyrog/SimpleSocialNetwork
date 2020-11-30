using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public string User1Username { get; set; }
        public string User2Username { get; set; }
        public DateTime TimeSent { get; set; }
        public string MessageText { get; set; }
    }
}
