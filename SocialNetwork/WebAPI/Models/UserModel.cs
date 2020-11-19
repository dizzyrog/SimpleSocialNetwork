using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string University { get; set; }
        public string AboutMe { get; set; }
        public int? Age { get; set; }
        // public ICollection<User> Friends { get; set; }
        //public ICollection<FriendshipModel> Friendships { get; set; }
        //public ICollection<MessageModel> Messages { get; set; }
    }
}
