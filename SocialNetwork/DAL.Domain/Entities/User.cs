using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Domain
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string University { get; set; }
        public string AboutMe { get; set; }
        public int Age { get; set; }
        public ICollection<User> Friends { get; set; }
        public ICollection<Friendship> Friendships { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
