using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected string GetCurrentUserId()
        {
            ClaimsIdentity claimsIdentity = User.Identities.FirstOrDefault();
            IEnumerable<Claim> claims = claimsIdentity.Claims;
            var id = claims.FirstOrDefault(x => String.Equals(x.Type, "UserID")).Value;
            return id;
        }
    }
}
