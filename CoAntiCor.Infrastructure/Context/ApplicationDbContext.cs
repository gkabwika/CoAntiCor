using CoAntiCor.Data;
using CoAntiCor.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoAntiCor.Infrastructure.Context
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

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
        }
    }


}
