using CoAntiCor.Infrastructure.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoAntiCor.Infrastructure.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        //PM> Add-Migration InitialDomain -Context ApplicationDbContext -StartupProject CoAntiCor -OutputDir "Data/Migrations"
        //PM> Update-Database -Context ApplicationDbContext -StartupProject CoAntiCor
        //PM> Add-Migration AddedNewEntities -Context ApplicationDbContext -StartupProject CoAntiCor -OutputDir "Data/Migrations"
        //PM> Update-Database
    
    }


}
