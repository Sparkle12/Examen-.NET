using Microsoft.EntityFrameworkCore;
using Server.Repository;
using webapi.Models;

namespace webapi.Repositories
{
    public class EdituraRepository : GenericRepository<Editura>
    {
        public EdituraRepository(ExamenDbContext context) : base(context) { } 
        
        public override async Task<Editura> FindByIdAsync(int id)
        {
            return await _table.Include(e => e.Autori).FirstOrDefaultAsync(e => e.Id == id);
        }

        public override Editura FindById(int id)
        {
            return _table.Include(e => e.Autori).FirstOrDefault(e => e.Id == id);
        }

        public Editura FindByName(string name)
        {
            return _table.Include(e => e.Autori).FirstOrDefault(e => e.Name == name);
        }
    }
}
