namespace webapi.Models
{
    public class Editura : BaseClass
    {
        public string Name { get; set; }
        public List<Autor> Autori {  get; set; }
    }
}
