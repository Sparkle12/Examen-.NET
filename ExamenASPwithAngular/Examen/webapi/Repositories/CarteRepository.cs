using Microsoft.EntityFrameworkCore;
using Server.Repository;
using webapi.Models;

namespace webapi.Repositories
{
    public class CarteRepository : GenericRepository<Carte>
    {
        public CarteRepository (ExamenDbContext context) : base (context) { }

        public override Carte FindById(int id)
        {
            return _table.Include(c => c.Autori).FirstOrDefault(c => c.Id == id);
        }

        public override async Task<Carte> FindByIdAsync(int id)
        {
            return await _table.Include(c => c.Autori).FirstOrDefaultAsync(c => c.Id == id);
        }

        public Carte FindByName(string name)
        {
            return  _table.Include(c => c.Autori).FirstOrDefault(c => c.Name == name);
        }
    }
}
