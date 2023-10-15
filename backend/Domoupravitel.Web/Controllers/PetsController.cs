using Domoupravitel.Data.UnitOfWork;
using Domoupravitel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Domoupravitel.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PetsController : Controller
    {
        private readonly IDomoupravitelData _data;

        public PetsController(IDomoupravitelData data)
        {
            this._data = data;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<Pet> All()
        {
            var result = this._data.Pets.All();
            return result;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(Pet request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existing = this._data.Pets.SearchFor(c => c.Number == request.Number).FirstOrDefault();
            if (existing != null) return BadRequest("Pet already exists");

            var pet = new Pet
            {
                Id = Guid.NewGuid(),
                Number = request.Number,
                Name = request.Name ?? string.Empty,
            };
            this._data.Pets.Add(pet);
            this._data.SaveChanges();

            return CreatedAtAction(nameof(Create), pet);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(Pet request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var pet = this._data.Pets.SearchFor(c => c.Id == request.Id).FirstOrDefault();
            if (pet == null) return BadRequest("Pet not found");

            if (string.IsNullOrEmpty(request.Number)) return BadRequest("Pet number not provided");

            if (this._data.Pets.All().Any(c => c.Number == request.Number && c != pet))
                return BadRequest("Pet with this number already exists");

            pet.Number = request.Number;
            pet.Name= request.Name ?? string.Empty;

            this._data.Pets.Update(pet);
            this._data.SaveChanges();
            return CreatedAtAction(nameof(Update), pet);
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(Pet request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var pet = this._data.Pets.SearchFor(c => c.Id == request.Id).FirstOrDefault();
            if (pet == null) return BadRequest("Pet not found");

            this._data.Pets.Delete(pet);
            this._data.SaveChanges();
            return CreatedAtAction(nameof(Delete), pet.Id);
        }
    }
}
