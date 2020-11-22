using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using DAL.Domain;
using BLL.Interfaces;
using AutoMapper;
using BLL.DTO;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private UserManager<UserEntity> _userManager;
        private IUserService _userService;
        private SignInManager<UserEntity> _signInManager;
        private IMapper _mapper;
        private readonly ApplicationSettings _appSettings;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager,
            IOptions<ApplicationSettings> appSettings, ILogger<AccountController> logger, IMapper mapper, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
            _logger = logger;
            _mapper = mapper;
            _userService = userService;
        }

        
        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        //api/Account/register
        public async Task<ActionResult<UserModel>> PostUser(UserModel model)
        {
            try
            {
                var UserEntity = new UserEntity()
                {
                    UserName = model.UserName,
                    Email = model.Email
                };
                var result = await _userManager.CreateAsync(UserEntity, model.Password);
                await _userManager.AddToRoleAsync(UserEntity,model.Role);

                var user = await _userManager.FindByNameAsync(model.UserName);

                
                var userDTO = _mapper.Map<UserModel, UserDTO>(model);
                await _userService.AddUser(userDTO);

                await Login(model);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        //api/account/login
        public async Task<IActionResult> Login(UserModel model)
        {
            _logger.LogWarning("Login method called!!!");
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                //Get role assigned to the user
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();
                
                var tokenDescriptor = new SecurityTokenDescriptor 
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var userDTO = _mapper.Map<UserModel, UserDTO>(model);
                userDTO.UserIdentityId = user.Id;
                _userService.UpdateIdentityId(userDTO);
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });
        }
    }
}
