using webapi.Models;
namespace webapi.DTOs
{
    public class EdituraDTO
    {
        public EdituraDTO(Editura e)
        {
            Name = e.Name;
            foreach(Autor a in e.Autori)
            {
                Autori.Add(new AutorDTO(a));
            }
        }
        public string Name { get; set; }

        public List<AutorDTO> Autori {  get; set; }
    }
}
