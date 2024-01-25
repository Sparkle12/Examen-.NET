using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi
{
    public class ExamenDbContext : DbContext
    {
        public ExamenDbContext (DbContextOptions<ExamenDbContext> options) : base(options) { }

        public DbSet<Carte> Carti { get; set; }
        public DbSet<Autor> Autori { get; set; }
        public DbSet<Editura> Edituri { get; set; }
    }
}
