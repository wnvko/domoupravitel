using Domoupravitel.Data.UnitOfWork;
using Domoupravitel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Domoupravitel.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PropertiesController : Controller
    {
        private readonly IDomoupravitelData _data;

        public PropertiesController(IDomoupravitelData data)
        {
            this._data = data;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<Property> All()
        {
            var result = this._data.Properties.All();
            return result;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(Property request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existing = this._data.Properties.SearchFor(p => p.Number == request.Number).FirstOrDefault();
            if (existing != null) return BadRequest("Property already exists");

            var property = new Property
            {
                Id = Guid.NewGuid(),
                Number = request.Number,
                Type = request.Type,
                Share = request.Share,
            };
            this._data.Properties.Add(property);
            this._data.SaveChanges();

            return CreatedAtAction(nameof(Create), property);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(Property request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var property = this._data.Properties.SearchFor(c => c.Id == request.Id).FirstOrDefault();
            if (property == null) return BadRequest("Property not found");

            if (string.IsNullOrEmpty(request.Number)) return BadRequest("Property number not provided");

            if (this._data.Properties.All().Any(p => p.Number == request.Number && p != property))
                return BadRequest("Property with this number already exists");

            property.Number = request.Number;
            property.Type = request.Type;
            property.Share = request.Share;

            this._data.Properties.Update(property);
            this._data.SaveChanges();
            return CreatedAtAction(nameof(Update), property);
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(Property request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var property = this._data.Properties.SearchFor(p => p.Id == request.Id).FirstOrDefault();
            if (property == null) return BadRequest("Property not found");

            this._data.Properties.Delete(property);
            this._data.SaveChanges();
            return CreatedAtAction(nameof(Delete), property.Id);
        }
    }
}
