using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Repositories;
using webapi.Requests;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EdituraController : ControllerBase
    {
        private readonly EdituraRepository _edituraRep;
        private readonly AutorRepository _autorRep;

        public EdituraController(EdituraRepository edituraRep, AutorRepository autorRep)
        {
            _edituraRep = edituraRep;
            _autorRep = autorRep;
        }

        [HttpGet("{id}")]
        public async Task<Editura> GetById(int id)
        {
            return await _edituraRep.FindByIdAsync(id);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateEditura(CreateEdituraReq req)
        {
            if (_edituraRep.FindByName(req.Name) != null)
                return BadRequest("Editura exista deja");

            List<Autor> autori = new List<Autor>();
            
            foreach(int index in req.Autori) 
            {
                Autor autor = _autorRep.FindById(index);
                if (autor == null)
                    return BadRequest("Autorul nu exista");
                autori.Add(autor);
            }

            Editura editura = new Editura();
            editura.Name = req.Name;
            editura.Autori = autori;

            _edituraRep.Create(editura);
            _edituraRep.Save();

            return Ok("Editura a fost createa");
        }

    }
}
