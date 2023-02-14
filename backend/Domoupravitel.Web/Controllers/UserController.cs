using Domoupravitel.Data.UnitOfWork;
using Domoupravitel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domoupravitel.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IDomoupravitelData _data;

        public UserController(IDomoupravitelData data)
        {
            this._data = data;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return this._data.Users.All();
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        { 
            this._data.Users.Add(user);
            this._data.SaveChanges();
            return Ok(user);
        }
    }
}
