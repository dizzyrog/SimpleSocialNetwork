using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/friends")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        // GET: api/<FriendsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{userId}")]
        public ActionResult<FriendModel[]> GetFriendsById(int userId)
        {
            if (userId == 1)
            {
                FriendModel[] friendModels =
                {    new FriendModel()
                    {
                    Id = 4,
                    Email = "del.marco@gmail.com",
                    UserName = "jojo"
                    },
                    new FriendModel()
                    {
                    Id = 5,
                    Email = "luke.danes@gmail.com",
                    UserName = "luke`s"
                    }
                };
                return Ok(friendModels);
            }
            else
            {
                FriendModel[] friendModels =
                {     new FriendModel()
                    {
                    Id = 1,
                    Email = "ada.love@gmail.com",
                    UserName = "ada.love"
                    },
                    new FriendModel()
                    {
                    Id = 2,
                    Email = "tim@gmail.com",
                    UserName = "timmy"
                    },
                    new FriendModel()
                    {
                    Id = 3,
                    Email = "rory.gilmore@gmail.com",
                    UserName = "rory"
                    }
                };
                return Ok(friendModels);
            }
            
        }

        // POST api/<FriendsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FriendsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FriendsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
