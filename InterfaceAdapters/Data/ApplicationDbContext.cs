using InterfaceAdapters.Models;
using Microsoft.EntityFrameworkCore;

namespace InterfaceAdapters.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PetModel> Pets { get; set; }
    }
}
