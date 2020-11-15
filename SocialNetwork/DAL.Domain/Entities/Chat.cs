using DAL.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Domain
{
    public class Chat : BaseEntity
    {
        public int FriendshipId { get; set; }
        public ICollection<Message> Message { get; set; }
        public ICollection<Friendship> Friendships { get; set; }
    }
}
