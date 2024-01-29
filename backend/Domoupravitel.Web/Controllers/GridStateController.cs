using System.Xml.Linq;
using Domoupravitel.Data.UnitOfWork;
using Domoupravitel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Domoupravitel.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GridStateController : Controller
    {
        private readonly IDomoupravitelData _data;

        public GridStateController(IDomoupravitelData data)
        {
            this._data = data;
        }

        [HttpGet]
        [Route("get/{name}")]
        public IActionResult All(string name)
        {
            if (string.IsNullOrEmpty(name)) return BadRequest("Name not provided for grid state");

            var gridState = this._data.GridStates.SearchFor(s => s.GridName == name).FirstOrDefault();
            if (gridState == null) return BadRequest("Grid state not found");

            return Ok(gridState);
        }

        [HttpPost]
        [Route("put")]
        public IActionResult Create(GridState gridState)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (string.IsNullOrEmpty(gridState.GridName)) return BadRequest("Name not provided for grid state");

            var existing = this._data.GridStates.SearchFor(s => s.GridName == gridState.GridName).FirstOrDefault();
            if (existing == null)
            {
                existing = new GridState
                {
                    Id = Guid.NewGuid(),
                    GridName = gridState.GridName,
                    Options = gridState.Options,
                };
                this._data.GridStates.Add(existing);
            }
            else
            {
                existing.Options = gridState.Options;
                this._data.GridStates.Update(existing);
            }

            this._data.SaveChanges();
            return Ok(existing);
        }
    }
}
