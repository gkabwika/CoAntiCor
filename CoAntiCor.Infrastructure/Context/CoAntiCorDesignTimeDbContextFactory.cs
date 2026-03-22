
using CoAntiCor.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

/// <summary>
/// 2.	Add design-time factories (recommended if EF tools cannot discover the contexts)
/// •	Create one per context so EF tools can instantiate contexts when running from the CLI/VS.
/// •	The MigrationsHistoryTable(...) call prevents collisions if both contexts share the same DB (each context keeps its own migration history table).
/// </summary>
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CoAntiCorDbContext>
{
    public CoAntiCorDbContext CreateDbContext(string[] args)
    {
        var basePath = Directory.GetCurrentDirectory();
        // if running tools from solution root, adjust path to API project where appsettings lives:
        var config = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile(Path.Combine("..", "CoAntiCor.API", "appsettings.json"), optional: true)
            //.AddEnvironmentVariables()
            .Build();

         var conn = config.GetConnectionString("DefaultConnection")
                           ?? Environment.GetEnvironmentVariable("APP__DefaultConnection")
                           ?? "Server=DESKTOP-M3G136G;Database=COANTICOR_DEV;Trusted_Connection=True;";

        var builder = new DbContextOptionsBuilder<CoAntiCorDbContext>()
            .UseSqlServer(conn, o => o.MigrationsHistoryTable("__EFMigrationsHistory_App"));

        return new CoAntiCorDbContext(builder.Options);
    }
}

//•	Either run both updates (specify the startup project) or let your deployment run dotnet ef database update per context.
//# project that contains DbContext (infrastructure) is -p; startup (API) is -s

//    # Select 'Default project' = CoAntiCor.Infrastructure in PMC
//Add-Migration AddCoreDomainEntities
//Update-Database

/*  COMMANDS TO RUN IN TERMINAL EF CORE MIGRATIONS:
 *  
1.# from solution root - CoAntiCorDbContext (project that defines the context = -p)
dotnet ef migrations add Initial_EGuce \
  -c CoAntiCorDbContext \
  -p CoAntiCor.Infrastructure \
  -s CoAntiCor.API \
  -o Infrastructure/Migrations/EGuce

2.# ApplicationDbContext (adjust project names as needed)
dotnet ef migrations add Initial_App \
  -c ApplicationDbContext \
  -p CoAntiCor.API \
  -s CoAntiCor.API \
  -o API/Migrations/Application

dotnet ef database update -c CoAntiCorDbContext -p CoAntiCor.Infrastructure -s CoAntiCor.API
dotnet ef database update -c ApplicationDbContext -p CoAntiCor.API -s CoAntiCor.API

/----------------------------------------------------/
PM Console:
1) 1. If both DbContexts are in the SAME project

/MyProject
   ApplicationDbContext.cs
   CoAntiCorDbContext.cs
   /Migrations
      /Identity
      /Domain

Commands:
Add-Migration InitialIdentity -Context ApplicationDbContext -StartupProject CoAntiCor.Api -OutputDir "Data/Migrations/Identity"

Add-Migration InitialDomain -Context CoAntiCorDbContext -StartupProject CoAntiCor.Api -OutputDir "Data/Migrations/Domain"

Migrations/Identity/xxxx_InitialIdentity.cs
Migrations/Domain/xxxx_InitialDomain.cs

2. If DbContexts are in DIFFERENT projects (recommended architecture)

/CoAntiCor.Api                ← Startup project
/CoAntiCor.APP           ← Contains ApplicationDbContext
/CoAntiCor.Infrastructure     ← Contains CoAntiCorDbContext

Commands:

Add-Migration InitialIdentity `
    -Context ApplicationDbContext `
    -Project CoAntiCor.Identity `
    -StartupProject CoAntiCor.Api `
    -OutputDir "Migrations"

Add-Migration InitialDomain `
    -Context CoAntiCorDbContext `
    -Project CoAntiCor.Infrastructure `
    -StartupProject CoAntiCor.Api `
    -OutputDir "Migrations"

This ensures:

Identity migrations go into CoAntiCor.Identity/Migrations

Domain 

///////////////////////////////////////
///
PM> Add-Migration InitialDomain -Context CoAntiCorDbContext -StartupProject CoAntiCor.Api -OutputDir "Data/Migrations/Domain"
PM> Update-Database -Context CoAntiCorDbContext -StartupProject CoAntiCor.Api
 
PM> Add-Migration InitialIdentity -Context ApplicationDbContext -StartupProject CoAntiCor.Api -OutputDir "Data/Migrations/Identity"
PM> Update-Database -Context ApplicationDbContext -StartupProject CoAntiCor.API

PM> Remove-Migration -Context ApplicationDbContext -StartupProject CoAntiCor.Api

 PM> Add-Migration AddedMenuAndNewEntity -Context CoAntiCorDbContext -StartupProject CoAntiCor.Api -OutputDir "Data/Migrations/Domain"
PM> Update-Database -Context CoAntiCorDbContext -StartupProject CoAntiCor.API

PM> Add-Migration AddedServiceRequestEventAndNewEntity -Context CoAntiCorDbContext -StartupProject CoAntiCor.Api -OutputDir "Data/Migrations/Domain"
 */