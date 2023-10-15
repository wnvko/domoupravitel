using Domoupravitel.Data.UnitOfWork;
using Domoupravitel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Domoupravitel.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarsController : Controller
    {
        private readonly IDomoupravitelData _data;

        public CarsController(IDomoupravitelData data)
        {
            this._data = data;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<Car> All()
        {
            var result = this._data.Cars.All();
            return result;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(Car request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existing = this._data.Cars.SearchFor(c => c.Number == request.Number).FirstOrDefault();
            if (existing != null) return BadRequest("Car already exists");

            var car = new Car
            {
                Id = Guid.NewGuid(),
                Number = request.Number,
                Brand = request.Brand ?? string.Empty,
                Color = request.Color ?? string.Empty,
            };
            this._data.Cars.Add(car);
            this._data.SaveChanges();

            return CreatedAtAction(nameof(Create), car);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(Car request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var car = this._data.Cars.SearchFor(c => c.Id == request.Id).FirstOrDefault();
            if (car == null) return BadRequest("Car not found");

            if (string.IsNullOrEmpty(request.Number)) return BadRequest("Car number not provided");

            if (this._data.Cars.All().Any(c => c.Number == request.Number && c != car))
                return BadRequest("Car with this number already exists");

            car.Number = request.Number;
            car.Brand = request.Brand ?? string.Empty;
            car.Color = request.Color ?? string.Empty;

            this._data.Cars.Update(car);
            this._data.SaveChanges();
            return CreatedAtAction(nameof(Update), car);
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(Car request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var car = this._data.Cars.SearchFor(c => c.Id == request.Id).FirstOrDefault();
            if (car == null) return BadRequest("Car not found");

            this._data.Cars.Delete(car);
            this._data.SaveChanges();
            return CreatedAtAction(nameof(Delete), car.Id);
        }
    }
}
