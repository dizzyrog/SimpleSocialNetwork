using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/friends")]
    [ApiController]
    public class FriendsController : BaseController
    {
        private readonly IFriendshipService _friendshipService;
        private readonly IMapper _mapper;
        public FriendsController(IFriendshipService friendshipService, IMapper mapper)
        {
            _friendshipService = friendshipService;
            _mapper = mapper;
        }
        // GET: api/<FriendsController>
        //TODO change route to friends/user/{userId}
        [HttpGet("{userId}")]
       // [Authorize(Roles = "Admin, User")]
        public async  Task<ActionResult<IEnumerable<UserDTO>>> GetFriendsByUserIdAsync()
        {
            var userId = GetCurrentUserId();
            var friends = await _friendshipService.GetFriendsByUserIdAsync(3);
            return Ok(friends);
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
