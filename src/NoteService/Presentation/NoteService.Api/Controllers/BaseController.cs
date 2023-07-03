using Demo1.Data.Enums;
using Demo1.Helper.Models;
using IdentityModel;
using Microsoft.AspNetCore.Mvc;

namespace NoteService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class BaseController : ControllerBase
    {
        protected RequestedUser RequestedUser
        {
            get
            {
                var idClaims = from c in User.Claims.Where(f => f.Type == JwtClaimTypes.Id) select new { c.Value };
                var roleClaims = from c in User.Claims.Where(f => f.Type == JwtClaimTypes.Role) select new { c.Value };
                var fullnameClaims = from c in User.Claims.Where(f => f.Type == JwtClaimTypes.PreferredUserName) select new { c.Value };
                var emailClaims = from c in User.Claims.Where(f => f.Type == JwtClaimTypes.Email) select new { c.Value };
                var phoneClaims = from c in User.Claims.Where(f => f.Type == "Phone") select new { c.Value };
                //var uuidClaims = from c in User.Claims.Where(f => f.Type == "uuid") select new { c.Value };
                //var spregisterno = from c in User.Claims.Where(f => f.Type == "SpRegister") select new { c.Value };
                return new RequestedUser
                {
                    Id = idClaims.FirstOrDefault()!.Value,
                    FullName = fullnameClaims.FirstOrDefault()!.Value,
                    Role = (AuthRole) Enum.Parse(typeof(AuthRole), roleClaims.FirstOrDefault()!.Value, true),
                    Email = emailClaims.FirstOrDefault()!.Value,
                    Phone = phoneClaims.FirstOrDefault()!.Value,
                    //Email = emailClaims.FirstOrDefault()!.Value,                    
                    //Uuid = uuidClaims.FirstOrDefault()!.Value,
                    //SpRegister = spregisterno.FirstOrDefault()!.Value

                };
            }
        }
    }
}
