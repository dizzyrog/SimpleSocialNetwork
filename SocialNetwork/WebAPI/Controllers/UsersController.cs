using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/users
        [HttpGet]
        public ActionResult<UserModel[]> GetUsers()
        {
            UserModel[] UserModels =
               {    new UserModel()
                    {
                    Id = 4,
                    Email = "del.marco@gmail.com",
                    UserName = "jojo"
                    },
                    new UserModel()
                    {
                    Id = 5,
                    Email = "luke.danes@gmail.com",
                    UserName = "luke`s"
                    },
                    new UserModel()
                    {
                    Id = 1,
                    Email = "ada.love@gmail.com",
                    UserName = "ada.love"
                    },
                    new UserModel()
                    {
                    Id = 2,
                    Email = "tim@gmail.com",
                    UserName = "timmy"
                    },
                    new UserModel()
                    {
                    Id = 3,
                    Email = "rory.gilmore@gmail.com",
                    UserName = "rory"
                    }
               };
            return Ok(UserModels);
        }
    

        // GET api/<UsersController>/5
        [HttpGet("{userId}")]
        public ActionResult<UserModel> GetUserById(int userId)
        {
            switch (userId)
            {
                case 1:
                    return Ok(new UserModel()
                    {
                        Id = 1,
                        Email = "ada.love@gmail.com",
                        UserName = "ada.love"
                    });
                case 2:
                    return Ok(new UserModel()
                    {
                        Id = 2,
                        Email = "tim@gmail.com",
                        UserName = "timmy"
                    });
                case 3:
                    return Ok(new UserModel()
                    {
                        Id = 3,
                        Email = "rory.gilmore@gmail.com",
                        UserName = "rory"
                    });
                case 4:
                    return Ok(new UserModel()
                    {
                        Id = 4,
                        Email = "del.marco@gmail.com",
                        UserName = "jojo"
                    });
                case 5:
                    return Ok(new UserModel()
                    {
                        Id = 5,
                        Email = "luke.danes@gmail.com",
                        UserName = "luke`s"
                    });
                default:
                 return NotFound();
            }
            
        }


        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void PutUserById(int id, [FromBody] string value)
        {
            //return Ok("");
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteUserById(int id)
        {
            return Ok();
        }
    }
}
