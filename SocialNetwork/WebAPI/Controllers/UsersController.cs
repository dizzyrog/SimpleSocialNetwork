using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    [Route("api/users")]
    //[Authorize(Roles = "Admin, User")]
    [ApiController]
    public class UsersController : ControllerBase
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
        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDTO>> GetUserByIdAsync(int userId)
        {
            var res = await _userService.GetUserByIdAsync(userId);

            //TODO create a method for check
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();

        }


        // PUT api/<UsersController>/5
        [HttpPatch]
        public ActionResult UpdateUserById([FromBody] UserModel userModel)
        {
            var user = _mapper.Map<UserModel, UserDTO>(userModel);
            _userService.UpdateUser(user);
            return Ok();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            _userService.DeleteUser(user);
            return Ok();
        }

    }
}
