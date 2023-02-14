// https://medium.com/geekculture/how-to-add-jwt-authentication-to-an-asp-net-core-api-84e469e9f019
using Domoupravitel.Data.UnitOfWork;
using Domoupravitel.Models;
using Domoupravitel.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Domoupravitel.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IDomoupravitelData _data;
        private readonly TokenService _tokenService;

        public AuthController(
            UserManager<IdentityUser> userManager,
            IDomoupravitelData data,
            TokenService tokenService)
        {
            this._userManager = userManager;
            this._data = data;
            this._tokenService = tokenService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegistrationRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await this._userManager
                .CreateAsync(new IdentityUser { UserName = request.Username }, request.Password);

            if (result.Succeeded)
            {
                request.Password = string.Empty;
                return CreatedAtAction(nameof(Register), new { UserName = request.Username }, request);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] RegistrationRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var managedUser = await this._userManager.FindByNameAsync(request.Username);
            if (managedUser == null) return BadRequest("Bad credentials");

            var isPasswordValid = await this._userManager.CheckPasswordAsync(managedUser, request.Password);
            if (!isPasswordValid) return BadRequest("Bad credentials");

            var user = this._data.Users.All().FirstOrDefault(u => u.UserName == request.Username);
            if (user == null) return Unauthorized();

            var token = this._tokenService.CreateToken(user);
            this._data.SaveChanges();
            return Ok(new AuthResponse { Username = user.UserName, Token = token});
        }
    }
}
