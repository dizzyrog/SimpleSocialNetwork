using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Domain
{
    public class Message : BaseEntity
    {
        
        public string User1Id { get; set; }
        public string User2Id { get; set; }
        public DateTime TimeSent { get; set; }

        public string MessageText { get; set; }
    }
}
