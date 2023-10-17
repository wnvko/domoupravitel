using Data.UnitOfWork;
using Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonDescriptorsController : ControllerBase
    {
        private readonly IDomoupravitelData _data;

        public PersonDescriptorsController(IDomoupravitelData data)
        {
            this._data = data;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<PersonDescriptor> All()
        {
            var result = this._data.Descriptors.All();
            return result;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(PersonDescriptor request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existing = this._data.Descriptors.SearchFor(d => d.PersonId == request.PersonId && d.PropertyId == request.PropertyId).FirstOrDefault();
            if (existing != null) return BadRequest("PersonDescriptor already exists");

            var descriptor = new PersonDescriptor
            {
                Id = Guid.NewGuid(),
                PersonId = request.PersonId,
                PropertyId = request.PropertyId,
                Type = request.Type,
                Residence = request.Residence,
                MonthsInHouse = request.MonthsInHouse,
                RegisteredOn = request.RegisteredOn,
                UnRegisteredOn = request.UnRegisteredOn,
            };
            this._data.Descriptors.Add(descriptor);
            this._data.SaveChanges();

            return CreatedAtAction(nameof(Create), descriptor);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(PersonDescriptor request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var descriptor = this._data.Descriptors.SearchFor(d => d.Id == request.Id).FirstOrDefault();
            if (descriptor == null) return BadRequest("PersonDescriptor not found");

            if (request.PersonId == Guid.Empty) return BadRequest("Person Id not provided");
            if (request.PropertyId == Guid.Empty) return BadRequest("Property Id not provided");

            var person = this._data.People.All().FirstOrDefault(p => p.Id == request.PersonId);
            if (person == null) return BadRequest("Person not found");

            var property = this._data.Properties.All().FirstOrDefault(p => p.Id == request.PropertyId);
            if (property == null) return BadRequest("Property not found");

            if (this._data.Descriptors.All().Any(d => d.PersonId == request.PersonId && d.PropertyId == request.PropertyId && d != descriptor))
                return BadRequest("PersonDescriptor already exists");

            descriptor.PersonId = request.PersonId;
            descriptor.Person = person;
            person.Descriptors.Add(descriptor);
            descriptor.PropertyId = request.PropertyId;
            descriptor.Property = property;
            property.People.Add(descriptor);
            descriptor.Type = request.Type;
            descriptor.Residence = request.Residence;
            descriptor.MonthsInHouse = request.MonthsInHouse;
            descriptor.RegisteredOn = request.RegisteredOn;
            descriptor.UnRegisteredOn = request.UnRegisteredOn;

            this._data.Descriptors.Update(descriptor);
            this._data.SaveChanges();
            return CreatedAtAction(nameof(Update), descriptor);
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(PersonDescriptor request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var descriptor = this._data.Descriptors.SearchFor(p => p.Id == request.Id).FirstOrDefault();
            if (descriptor == null) return BadRequest("PersonDescriptor not found");

            this._data.Descriptors.Delete(descriptor);
            this._data.SaveChanges();
            return CreatedAtAction(nameof(Delete), descriptor.Id);
        }
    }
}

