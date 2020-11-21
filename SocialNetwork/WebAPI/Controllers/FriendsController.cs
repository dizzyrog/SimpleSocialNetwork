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

        // GET: api/friends
        [Route("friend")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<UserDTO>>> SearchFriendsAsync([FromBody] SearchModel searchModel)
        {
            var searchDTO = _mapper.Map<SearchModel, SearchDTO>(searchModel);
            var res = await _friendshipService.SearchFriendsAsync(searchDTO);
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }
       
        [Route("user")]
        [HttpGet]
       // [Authorize(Roles = "Admin, User")]
        public async  Task<ActionResult<IEnumerable<UserDTO>>> GetFriendsByUserIdAsync()
        {
            var userId = GetCurrentUserId();
            var friends = await _friendshipService.GetFriendsByUserIdAsync(userId);
            return Ok(friends);
        }
        //[Route("~/")]
        [HttpPost]
        public async Task<ActionResult> AddFriendAsync([FromBody] UserModel friend)
        {
            try
            {
                var userId = GetCurrentUserId();
                var friendDTO = _mapper.Map<UserModel, UserDTO>(friend);
                await _friendshipService.AddFriendshipAsync(friendDTO, userId);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
                throw e;
                
            }
            
        }
    }
}
