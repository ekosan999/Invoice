using Invoice.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Invoices> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoices>()
                .HasKey(x => x.Id);
            modelBuilder.HasSequence<int>("InvoiceId");
            modelBuilder.Entity<Invoices>()
                .Property(x => x.Id)
                .HasDefaultValueSql("NEXT VALUE FOR InvoiceId");
            base.OnModelCreating(modelBuilder);

        }
    }
    
}
