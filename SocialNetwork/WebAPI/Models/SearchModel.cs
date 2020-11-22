using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class SearchModel
    {
        public string Name { get; set; }
        public string Country {get; set;}
        public string City { get; set; }
        public string University { get; set; }
        public string Email { get; set; }
        public int? AgeMin { get; set; }
        public int? AgeMax { get; set; }
    }
}
