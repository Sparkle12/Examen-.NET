using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Models;
using webapi.Repositories;
using webapi.Requests;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly AutorRepository _autorRep;
        private readonly CarteRepository _carteRep;
        public AutorController(AutorRepository autorRep, CarteRepository carteRep) 
        {
            _autorRep = autorRep;
            _carteRep = carteRep;
        }
        [HttpGet("all")]
        public async Task<List<AutorDTO>> GetAll()
        {
            var autori = await _autorRep.GetAll();
            var ret = new List<AutorDTO>();
            foreach (var autor in autori)
                ret.Add(new AutorDTO(autor));
            return ret;
        }

        [HttpGet("{id}")]
        public async Task<AutorDTO> GetByIdAsync([FromRoute] int id)
        {
            return new AutorDTO(await _autorRep.FindByIdAsync(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAutorAsync(CreateAuthorReq req)
        {
            if(_autorRep.FindByName(req.Name) != null)
            {
                return BadRequest("Autorul exista deja");
            }

            List<Carte> carti = new List<Carte>();  
            foreach(int index in req.Carti)
            {
                Console.WriteLine(index);
                Carte carte = _carteRep.FindById(index);
                if (carte == null)
                    return BadRequest("Cartea nu exista");

                carti.Add(carte);
            }

            Autor autor = new Autor();
            autor.Carti = carti;
            autor.Name = req.Name;

            _autorRep.Create(autor);
            _autorRep.Save();

            return Ok("Autorul a fost creat");
        }
    }
}
