using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarteController : ControllerBase
    {
        private readonly CarteRepository _carteRep;

        public CarteController(CarteRepository carteRep)
        {
            _carteRep = carteRep;
        }

        [HttpGet("{id}")]
        public async Task<CarteDTO> GetById([FromRoute] int id)
        {
            return new CarteDTO(await _carteRep.FindByIdAsync(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCarte([FromBody] Carte c)
        {
            if(_carteRep.FindByName(c.Name) != null) 
            {
                return BadRequest("Cartea exista deja");
            }

            _carteRep.Create(c);
            _carteRep.Save();

            return Ok("Cartea a fost creata");
        }
    }
}
