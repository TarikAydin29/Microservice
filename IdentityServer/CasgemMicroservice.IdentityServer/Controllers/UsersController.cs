using CasgemMicroservice.IdentityServer.Dtos;
using CasgemMicroservice.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace CasgemMicroservice.IdentityServer.Controllers
{
    //Ekledik
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SingUpDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.Username,
                Email = dto.Email,
                City = dto.City,
                NameSurname = dto.NameSurname
            };
            await userManager.CreateAsync(user, dto.Password);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var value = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
            var user = await userManager.FindByIdAsync(value.Value);
            return Ok(new
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                City = user.City
            });
        }
    }
}
