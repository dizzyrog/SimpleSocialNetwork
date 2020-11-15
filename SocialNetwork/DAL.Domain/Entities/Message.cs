﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Domain
{
    public class Message : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }

        public string MessageText { get; set; }
    }
}
