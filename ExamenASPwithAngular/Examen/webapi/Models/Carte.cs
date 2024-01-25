namespace webapi.Models
{
    public class Carte : BaseClass 
    {
        public string Name { get; set; }
        public List<Autor>? Autori { get; set; }
    }
}
