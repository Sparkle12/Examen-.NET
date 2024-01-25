using webapi.Models;

namespace webapi.DTOs
{
    public class CarteDTO
    {
        public CarteDTO(Carte c) 
        {
            Name = c.Name;

            foreach (Autor a in c.Autori)
            {
                Autori.Add(new AutorDTO(a));
            }
        }

        public string Name { get; set; }
        public List<AutorDTO> Autori {  get; set; }
    }
}
