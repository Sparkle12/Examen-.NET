using webapi.Models;

namespace webapi.DTOs
{
    public class AutorDTO
    {
        public AutorDTO(Autor a) { Name = a.Name; }
        public string Name { get; set; }
    }
}
