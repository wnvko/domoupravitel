using Domoupravitel.Data.UnitOfWork;
using Domoupravitel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Domoupravitel.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChipController : Controller
    {
        private readonly IDomoupravitelData _data;

        public ChipController(IDomoupravitelData data)
        {
            this._data = data;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<Chip> All()
        {
            var result = this._data.Chips.All();
            return result;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(Chip request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existing = this._data.Chips.SearchFor(c => c.Id == request.Id).FirstOrDefault();
            if (existing != null) return BadRequest("Chip already exists");

            var chip = new Chip
            {
                Id = Guid.NewGuid(),
                Number = request.Number,
                Disabled = request.Disabled,
                PersonId = request.PersonId,
            };
            this._data.Chips.Add(chip);
            this._data.SaveChanges();

            return CreatedAtAction(nameof(Create), chip);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(Chip request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var chip = this._data.Chips.SearchFor(c => c.Id == request.Id).FirstOrDefault();
            if (chip == null) return BadRequest("Chip not found");

            if (string.IsNullOrEmpty(request.Number)) return BadRequest("Chip number not provided");
            if (request.PersonId == Guid.Empty) return BadRequest("Chip person not provided");

            if (this._data.Chips.All().Any(c => c.Number == request.Number && c != chip))
                return BadRequest("Chip with this number already exists");

            chip.Number = request.Number;
            chip.Disabled = request.Disabled;
            chip.PersonId = request.PersonId;

            this._data.Chips.Update(chip);
            this._data.SaveChanges();
            return CreatedAtAction(nameof(Update), chip);
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(Chip request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var chip = this._data.Chips.SearchFor(c => c.Id == request.Id).FirstOrDefault();
            if (chip == null) return BadRequest("Chip not found");

            this._data.Chips.Delete(chip);
            this._data.SaveChanges();
            return CreatedAtAction(nameof(Delete), chip.Id);
        }
    }
}
