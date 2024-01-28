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
    public class PersonController : Controller
    {
        private readonly IDomoupravitelData _data;

        public PersonController(IDomoupravitelData data)
        {
            this._data = data;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<Person> All()
        {
            var result = this._data.People
                .All()
                .Include(p => p.Descriptors.Select(d => d.Property))
                .Include(p => p.Chips)
                .ToList();
            var t = this._data.Properties
                .All()
                .ToList();
            var d = this._data.Descriptors
                .All()
                .Include(d => d.Person)
                .Include(d => d.Property)
                .ToList();
            var c = this._data.Chips
                .All()
                .ToList();
            return result;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(PersonRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existing = this._data.People.SearchFor(p => p.Name == request.Name).FirstOrDefault();
            if (existing != null) return BadRequest("Person already exists");

            var person = new Person
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email ?? string.Empty,
                Phone = request.Phone ?? string.Empty,
                BirthDate = request.BirthDate?.Date,
            };
            this._data.People.Add(person);
            this._data.SaveChanges();

            return CreatedAtAction(nameof(Create), person);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(Person request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var person = this._data.People.SearchFor(p => p.Id == request.Id).FirstOrDefault();
            if (person == null) return BadRequest("Person not found");

            if (!string.IsNullOrEmpty(person.Name))
                person.Name = request.Name;

            person.Phone = request.Phone;
            person.Email = request.Email;
            person.BirthDate = request.BirthDate?.Date;

            this._data.People.Update(person);
            this._data.SaveChanges();
            return CreatedAtAction(nameof(Update), person);
        }


        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(Person request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var person = this._data.People.SearchFor(p => p.Id == request.Id).FirstOrDefault();
            if (person == null) return BadRequest("Person not found");

            foreach (var descriptor in person.Descriptors)
            {
                this._data.Descriptors.Delete(descriptor);
            }

            this._data.People.Delete(person);
            this._data.SaveChanges();
            return CreatedAtAction(nameof(Delete), person.Id);
        }
    }
}
