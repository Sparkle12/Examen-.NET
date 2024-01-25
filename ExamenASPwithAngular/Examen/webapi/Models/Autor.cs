namespace webapi.Models
{
    public class Autor : BaseClass
    {
        public string Name { get; set; }
        public List<Carte> Carti { get; set; }
    }
}
