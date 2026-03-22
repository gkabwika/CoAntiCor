using CoAntiCor.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoAntiCor.Data
{
    public class ApplicationDbContext
        : IdentityDbContext<ApplicationUser>
    {
        //PM> Add-Migration InitialDomain -Context ApplicationDbContext -StartupProject CoAntiCor -OutputDir "Data/Migrations"
        //PM> Update-Database -Context ApplicationDbContext -StartupProject CoAntiCor
        //PM> Add-Migration AddedNewEntities -Context ApplicationDbContext -StartupProject CoAntiCor -OutputDir "Data/Migrations"
        //PM> Update-Database
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options) { }

        public DbSet<MenuItem> MenuItems => Set<MenuItem>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MenuItem>(e =>
            {
                e.ToTable("MenuItems");
                e.HasKey(x => x.Id);
                e.Property(x => x.Title).HasMaxLength(200).IsRequired();
                e.Property(x => x.Icon).HasMaxLength(200).IsRequired();
                e.Property(x => x.Url).HasMaxLength(400).IsRequired();
                e.Property(x => x.Role).HasMaxLength(100);
            });
        }
    }


}
