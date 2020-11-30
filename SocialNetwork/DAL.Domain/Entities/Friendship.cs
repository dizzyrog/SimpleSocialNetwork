using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Domain
{
    public class Friendship : BaseEntity
    {
        public string UserId { get; set; }
        public int FriendId { get; set; }
        public User Friend { get; set; }
    }
}
