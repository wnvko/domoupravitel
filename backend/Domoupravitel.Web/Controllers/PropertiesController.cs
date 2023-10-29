using System.Data.Entity;
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
            var result = this._data.Properties.All()
                .Include(p => p.People)
                .Include(p => p.Cars)
                .Include(p => p.Pets)
                .ToList();
            this._data.People.All().ToList();
            this._data.Descriptors.All()
                .Include(d => d.Person)
                .Include(d => d.Property)
                .ToList();
            this._data.Pets.All().ToList();
            this._data.Cars.All().ToList();
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

            var property = this._data.Properties.SearchFor(p => p.Id == request.Id).FirstOrDefault();
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

            foreach (var descriptor in property.People)
            {
                this._data.Descriptors.Delete(descriptor);
            }

            this._data.Properties.Delete(property);
            this._data.SaveChanges();
            return CreatedAtAction(nameof(Delete), property.Id);
        }

        [HttpPost]
        [Route("addCar")]
        public IActionResult AddCar(Car request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var property = this._data.Properties.SearchFor(p => p.Id == request.PropertyId).FirstOrDefault();
            if (property == null) return BadRequest("Property not found");

            var car = this._data.Cars.SearchFor(c => c.Number == request.Number).FirstOrDefault();
            if (car == null) return BadRequest("Car not found");

            car.PropertyId = request.PropertyId;
            this._data.Cars.Update(car);
            this._data.SaveChanges();
            return CreatedAtAction(nameof(AddCar), car);
        }

        [HttpPut]
        [Route("updateCar")]
        public IActionResult UpdateCar(Car request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var property = this._data.Properties.SearchFor(p => p.Id == request.PropertyId).FirstOrDefault();
            if (property == null) return BadRequest("Property not found");

            var car = this._data.Cars.SearchFor(c => c.Number == request.Number).FirstOrDefault();
            if (car == null) return BadRequest("Car not found");

            car.PropertyId = request.PropertyId;
            this._data.Cars.Update(car);
            this._data.SaveChanges();
            return CreatedAtAction(nameof(UpdateCar), car);
        }

        [HttpDelete]
        [Route("deleteCar")]
        public IActionResult DeleteCar(Car request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var property = this._data.Properties.SearchFor(p => p.Id == request.PropertyId).FirstOrDefault();
            if (property == null) return BadRequest("Property not found");

            var car = this._data.Cars.SearchFor(c => c.Id == request.Id).FirstOrDefault();
            if (car == null) return BadRequest("Car not found");

            car.PropertyId = null;
            car.Property = null;
            this._data.Cars.Update(car);
            this._data.SaveChanges();
            return CreatedAtAction(nameof(DeleteCar), car);
        }

        [HttpPost]
        [Route("addPet")]
        public IActionResult AddPet(Pet request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var property = this._data.Properties.SearchFor(p => p.Id == request.PropertyId).FirstOrDefault();
            if (property == null) return BadRequest("Property not found");

            var pet = this._data.Pets.SearchFor(p => p.Number == request.Number).FirstOrDefault();
            if (pet == null) return BadRequest("Pet not found");

            pet.PropertyId = request.PropertyId;
            this._data.Pets.Update(pet);
            this._data.SaveChanges();
            return CreatedAtAction(nameof(AddPet), pet);
        }

        [HttpPut]
        [Route("updatePet")]
        public IActionResult UpdatePet(Pet request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var property = this._data.Properties.SearchFor(p => p.Id == request.PropertyId).FirstOrDefault();
            if (property == null) return BadRequest("Property not found");

            var pet = this._data.Pets.SearchFor(p => p.Number == request.Number).FirstOrDefault();
            if (pet == null) return BadRequest("Pet not found");

            pet.PropertyId = request.PropertyId;
            this._data.Pets.Update(pet);
            this._data.SaveChanges();
            return CreatedAtAction(nameof(UpdatePet), pet);
        }

        [HttpDelete]
        [Route("deletePet")]
        public IActionResult DeletePet(Pet request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var property = this._data.Properties.SearchFor(p => p.Id == request.PropertyId).FirstOrDefault();
            if (property == null) return BadRequest("Property not found");

            var pet = this._data.Pets.SearchFor(c => c.Id == request.Id).FirstOrDefault();
            if (pet == null) return BadRequest("Pet not found");

            pet.PropertyId = null;
            pet.Property = null;
            this._data.Pets.Update(pet);
            this._data.SaveChanges();
            return CreatedAtAction(nameof(DeletePet), pet);
        }
    }
}
