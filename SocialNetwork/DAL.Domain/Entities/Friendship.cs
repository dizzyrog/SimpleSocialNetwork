using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Domain
{
    public class Friendship : BaseEntity
    {
        public int UserId { get; set; }
        [NotMapped]
        public User User { get; set; }
        public int FriendId { get; set; }
        public User Friend { get; set; }
        public int ChatId { get; set; }
       // public Chat Chat { get; set; }
        //TODO for how long have been friends
    }
}
