using Domoupravitel.Data.UnitOfWork;
using Domoupravitel.Models;
using Domoupravitel.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Domoupravitel.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IDomoupravitelData _data;
        private readonly TokenService _tokenService;

        public UserController(
            UserManager<IdentityUser> userManager,
            IDomoupravitelData data,
            TokenService tokenService)
        {
            this._userManager = userManager;
            this._data = data;
            this._tokenService = tokenService;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<IdentityUser>  All()
        {
            var result = this._data.Users.All();
            return result;
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
    }
}
