using System;
using System.Collections.Generic;

namespace BLL.DTO
{
    public class UserDTO
    {
        public string UserIdentityId { get; set; }
        public int Id { get; set; }
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
        // public ICollection<User> Friends { get; set; }
        public ICollection<FriendshipDTO> Friendships { get; set; }
    }
}
