using Domoupravitel.Data.UnitOfWork;
using Domoupravitel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Domoupravitel.Web.Controllers
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

            var existing = this._data.Descriptors.SearchFor(d => d.PersonId == request.PersonId).FirstOrDefault();
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

            if (this._data.Descriptors.All().Any(d => d.PersonId == request.PersonId && d != descriptor))
                return BadRequest("Property with this number already exists");

            descriptor.PersonId = request.PersonId;
            descriptor.PropertyId = request.PropertyId;
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

