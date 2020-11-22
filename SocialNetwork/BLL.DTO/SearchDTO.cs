using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class SearchDTO
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string University { get; set; }
        public string Email { get; set; }
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }
    }
}
