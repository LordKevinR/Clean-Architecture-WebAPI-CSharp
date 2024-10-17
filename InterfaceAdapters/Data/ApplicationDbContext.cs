using InterfaceAdapters.Models.Pets;
using InterfaceAdapters.Models.Sales;
using Microsoft.EntityFrameworkCore;

namespace InterfaceAdapters.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SaleModel>()
                .HasMany(s => s.Concepts)
                .WithOne()
                .HasForeignKey(c => c.SaleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ConceptModel>()
                .HasOne(c => c.Pet)
                .WithMany()
                .HasForeignKey(c => c.PetId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<PetModel> Pets { get; set; }
        public DbSet<SaleModel> Sales { get; set; }
        public DbSet<ConceptModel> Concepts { get; set; }
    }
}
