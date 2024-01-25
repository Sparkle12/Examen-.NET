using Microsoft.EntityFrameworkCore;
using Server.Repository;
using webapi.Models;

namespace webapi.Repositories
{
    public class AutorRepository : GenericRepository<Autor>
    {
        public AutorRepository(ExamenDbContext context): base(context) { }

        public override Autor FindById(int id)
        {
            return _table.Include(a => a.Carti).FirstOrDefault(a => a.Id == id);
        }

        public async override  Task<Autor> FindByIdAsync(int id)
        {
            return await _table.Include(a => a.Carti).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Autor> FindByNameAsync(string name)
        {
            return await _table.Include(a => a.Carti).FirstOrDefaultAsync(a => a.Name == name);
        }

        public Autor FindByName(string name) 
        {
            return _table.Include(a => a.Carti).FirstOrDefault(a => a.Name == name);
        }

    }
}
