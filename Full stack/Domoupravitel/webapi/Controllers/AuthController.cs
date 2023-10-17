// https://medium.com/geekculture/how-to-add-jwt-authentication-to-an-asp-net-core-api-84e469e9f019
using Data.UnitOfWork;
using Models;
using Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IDomoupravitelData _data;
        private readonly TokenService _tokenService;

        public AuthController(
            UserManager<User> userManager,
            IDomoupravitelData data,
            TokenService tokenService)
        {
            this._userManager = userManager;
            this._data = data;
            this._tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = this._data.Users.SearchFor(u => u.Name == request.Username).FirstOrDefault();
            if (user == null) return BadRequest("Bad credentials");

            var isPasswordValid = await this._userManager.CheckPasswordAsync(user, request.Password);
            if (!isPasswordValid) return BadRequest("Bad credentials");

            var token = this._tokenService.CreateToken(user);
            this._data.SaveChanges();
            return Ok(new AuthResponse { Username = user.UserName, Token = token});
        }
    }
}
