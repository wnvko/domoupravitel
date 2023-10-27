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
        private readonly UserManager<User> _userManager;
        private readonly IDomoupravitelData _data;
        private readonly TokenService _tokenService;

        public UserController(
            UserManager<User> userManager,
            IDomoupravitelData data,
            TokenService tokenService)
        {
            this._userManager = userManager;
            this._data = data;
            this._tokenService = tokenService;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<User> All()
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
                .CreateAsync(new User { Name = request.Username, UserName = request.Username, Role = request.Role!.Value }, request.Password);

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

        [HttpPut]
        [Route("changePassword")]
        public async Task<IActionResult> ChangePassword(UpdateRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (request.NewPassword != request.RepeatPassword)
            {
                return BadRequest("Not matching passwords");
            }

            var managedUser = this._data.Users
                .SearchFor(u => u.UserName == request.Username)
                .FirstOrDefault();
            if (managedUser == null) return BadRequest("User not found");

            var isPasswordValid = await this._userManager.CheckPasswordAsync(managedUser, request.Password);
            if (!isPasswordValid) return BadRequest("Invalid password");

            var result = await this._userManager.ChangePasswordAsync(managedUser, request.Password, request.NewPassword);
            if (result.Succeeded)
            {
                request.Password = string.Empty;
                request.NewPassword= string.Empty;
                request.RepeatPassword = string.Empty;
                return CreatedAtAction(nameof(Update), new { UserName = request.Username }, request);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(User request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var managedUser = this._data.Users
                .SearchFor(u => u.Id == request.Id)
                .FirstOrDefault();
            if (managedUser == null) return BadRequest("User not found");

            managedUser.UserName = request.UserName;
            managedUser.Name = request.UserName;
            managedUser.Role = request.Role;
            this._data.Users.Update(managedUser);
            this._data.SaveChanges();
            return CreatedAtAction(nameof(Update), managedUser, request);
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult<User> Delete(User request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var managedUser = this._data.Users
                .SearchFor(u => u.Id == request.Id)
                .FirstOrDefault();
            if (managedUser == null) return BadRequest("User not found");

            this._data.Users.Delete(managedUser);
            this._data.SaveChanges();
            return new OkObjectResult(managedUser);
        }
    }
}
