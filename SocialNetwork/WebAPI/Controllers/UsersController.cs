using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/users")]
    //[Authorize(Roles = "Admin, User")]
    [ApiController]
    public class UsersController : BaseController
    {

        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
    }
        // GET: api/users
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersAsync()
        {
            var res = await _userService.GetUsersAsync();
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }
    

        // GET api/<UsersController>/5
        [HttpGet]
        [Authorize]
        [Route("current")]
        public async Task<ActionResult<UserDTO>> GetCurrentUserByIdAsync()
        {
            var userId = GetCurrentUserId();
            var res = await _userService.GetUserByIdAsync(userId);
            
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();

        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserDTO>> GetUserByIdAsync(int id)
        {
            var res = await _userService.GetByIdAsync(id);

            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();

        }

        // PUT api/<UsersController>/5
        [HttpPatch]
        [Authorize]
        public ActionResult UpdateUser([FromBody] UserModel userModel)
        {
            var user = _mapper.Map<UserModel, UserDTO>(userModel);
            user.UserIdentityId = GetCurrentUserId();
            _userService.UpdateUser(user);
            return Ok();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> DeleteUserById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            _userService.DeleteUser(user);
            return Ok();
        }
        
    }
}
