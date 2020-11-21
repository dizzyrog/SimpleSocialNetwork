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
        private readonly UserManager<UserEntity> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UsersController(IUserService userService, IMapper mapper, UserManager<UserEntity> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
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
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserByIdAsync(int id)
        {
            var userId = GetCurrentUserId();
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
        public ActionResult UpdateUser([FromBody] UserModel userModel)
        {
            var user = _mapper.Map<UserModel, UserDTO>(userModel);
            user.UserIdentityId = GetCurrentUserId();
            _userService.UpdateUser(user);
            return Ok();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteUserById(int id)
        {
            //TODO delete by model not id mark as deleted
            var user = await _userService.GetByIdAsync(id);
            _userService.DeleteUser(user);
            return Ok();
        }
        
    }
}
