using CoAntiCor.Core.Domain;
using CoAntiCor.Core.Model;
using CoAntiCor.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Infrastructure.Context
{
    public class CoAntiCorDbContext : DbContext
    {
        public CoAntiCorDbContext(DbContextOptions<CoAntiCorDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();

        public DbSet<IncidentType> IncidentTypes => Set<IncidentType>();
        public DbSet<IncidentCategory> IncidentCategories => Set<IncidentCategory>();
        public DbSet<GovernmentOffice> GovernmentOffices => Set<GovernmentOffice>();

        public DbSet<Complaint> Complaints => Set<Complaint>();
        public DbSet<ComplaintAttachment> ComplaintAttachments => Set<ComplaintAttachment>();
        public DbSet<ProcessingPhase> ProcessingPhases => Set<ProcessingPhase>();
        public DbSet<ComplaintHistory> ComplaintHistories => Set<ComplaintHistory>();
        public DbSet<ComplaintReward> ComplaintRewards => Set<ComplaintReward>();
        public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
        public DbSet<ComplaintDraft> ComplaintDrafts => Set<ComplaintDraft>();
        public DbSet<ComplaintDraftActivity> ComplaintDraftActivities => Set<ComplaintDraftActivity>();
        public DbSet<ComplaintNumberSequence> ComplaintNumberSequences => Set<ComplaintNumberSequence>();
        public DbSet<MenuItem> MenuItems => Set<MenuItem>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /////////////////////////////////////

            // Complaint Number Sequence CONFIGURATION -------------------------------------

            modelBuilder.Entity<ComplaintNumberSequence>().HasData(
            new ComplaintNumberSequence
            {
                Id = 1,
                Year = DateTime.UtcNow.Year,
                LastNumber = 0
            });

            // USER ROLE CONFIGURATION -------------------------------------

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = Guid.Parse("11121111-2312-1111-3333-111117111111"),
                    Name = "Admin"
                },
                new Role
                {
                    Id = Guid.Parse("22212222-3333-2222-3333-222272622222"),
                    Name = "Citizen"
                },
                new Role
                {
                    Id = Guid.Parse("33134333-3223-1111-3333-333345333333"),
                    Name = "InternalStaff"
                },
                new Role
                {
                    Id = Guid.Parse("44544424-4454-2244-3354-444433444444"),
                    Name = "Manager"
                },
                new Role
                {
                    Id = Guid.Parse("55556555-5555-2155-5755-555352255555"),
                    Name = "Executive"
                },
                new Role
                {
                    Id = Guid.Parse("66162666-2266-7377-4466-616661166666"),
                    Name = "Inspector"
                },
                new Role
                {
                    Id = Guid.Parse("77737877-1277-5555-7577-777947777777"),
                    Name = "Prosecutor"
                },
                new Role
                {
                    Id = Guid.Parse("88734177-6277-2555-7567-872147377777"),
                    Name = "SpecialInvestigator"
                }
            );



            // COMPLAINT CONFIGURATION -------------------------------------

            modelBuilder.Entity<Complaint>()
                .HasIndex(c => c.ComplaintNumber)
                .IsUnique();

            modelBuilder.Entity<Complaint>()
                .HasOne(c => c.ReporterUser)
                .WithMany(u => u.ComplaintsInitiated)
                .HasForeignKey(c => c.ReporterUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProcessingPhase>()
                .HasOne(p => p.AssignedToUser)
                .WithMany(u => u.AssignedPhases)
                .HasForeignKey(p => p.AssignedToUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Complaint>()
                .HasOne(c => c.AssignedToUser)
                .WithMany()
                .HasForeignKey(c => c.AssignedToUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ComplaintReward>()
                .HasOne(r => r.Complaint)
                .WithOne(c => c.Reward)
                .HasForeignKey<ComplaintReward>(r => r.ComplaintId);

            // AUDIT CONFIGURATION -------------------------------------

            modelBuilder.Entity<AuditLog>()
       .HasIndex(a => a.TimestampUtc);

            modelBuilder.Entity<AuditLog>()
                .HasIndex(a => new { a.EntityType, a.EntityId });

            // Additional configuration as needed


            // MENU CONFIGURATION -------------------------------------

            modelBuilder.Entity<MenuItem>(e =>
            {
                e.ToTable("MenuItems");
                e.HasKey(x => x.Id);
                e.Property(x => x.Title).HasMaxLength(200).IsRequired();
                e.Property(x => x.Icon).HasMaxLength(200).IsRequired();
                e.Property(x => x.Url).HasMaxLength(400).IsRequired();
                e.Property(x => x.Role).HasMaxLength(100);
            });
            modelBuilder.Entity<MenuItem>().HasData(
                // Citizen Menu
                new MenuItem
                {
                    Id = 1,
                    Title = "Home",
                    TitleFrench = "Accueil",
                    Icon = "fa-solid fa-house",
                    Url = "/",
                    DisplayOrder = 1,
                    Role = null
                },
                new MenuItem
                {
                    Id = 2,
                    Title = "Report a Complaint",
                    TitleFrench = "Signaler une plainte",
                    Icon = "fa-solid fa-file-circle-plus",
                    Url = "/wizard",
                    DisplayOrder = 2,
                    Role = null
                },
                new MenuItem
                {
                    Id = 3,
                    Title = "Track My Complaint",
                    TitleFrench = "Suivre ma plainte",
                    Icon = "fa-solid fa-magnifying-glass",
                    Url = "/track-complaint",
                    DisplayOrder = 3,
                    Role = null
                },
                new MenuItem
                {
                    Id = 4,
                    Title = "FAQ",
                    TitleFrench = "Questions & Reponses",
                    Icon = "fa-solid fa-circle-question",
                    Url = "/faq",
                    DisplayOrder = 4,
                    Role = null
                },
                new MenuItem
                {
                    Id = 5,
                    Title = "Legal",
                    TitleFrench = "Mentions Légales",
                    Icon = "fa-solid fa-envelope",
                    Url = "/legal",
                    DisplayOrder = 5,
                    Role = null
                },
                 new MenuItem
                 {
                     Id = 6,
                     Title = "Contact",
                     TitleFrench = "Contactez-nous",
                     Icon = "fa-solid fa-envelope",
                     Url = "/contact",
                     DisplayOrder = 6,
                     Role = null
                 },
                // Staff Menu (Parent)
                new MenuItem
                {
                    Id = 10,
                    Title = "Staff",
                    TitleFrench = "Personnel",
                    Icon = "fa-solid fa-briefcase",
                    Url = "#",
                    DisplayOrder = 10,
                    Role = "Staff"
                },

                // Staff Children
                new MenuItem
                {
                    Id = 11,
                    Title = "Dashboard",
                    TitleFrench = "Tableau de bord",
                    Icon = "fa-solid fa-gauge",
                    Url = "/internal/dashboard",
                    DisplayOrder = 1,
                    ParentId = 10,
                    Role = "Staff"
                },
                new MenuItem
                {
                    Id = 12,
                    Title = "Complaints",
                    TitleFrench = "Plaintes",
                    Icon = "fa-solid fa-folder-open",
                    Url = "/internal/complaints",
                    DisplayOrder = 2,
                    ParentId = 10,
                    Role = "Staff"
                },
                new MenuItem
                {
                    Id = 13,
                    Title = "Assignments",
                    TitleFrench = "Attributions",
                    Icon = "fa-solid fa-user-check",
                    Url = "/internal/assignments",
                    DisplayOrder = 3,
                    ParentId = 10,
                    Role = "Staff"
                },
                new MenuItem
                {
                    Id = 14,
                    Title = "Audit Logs",
                    TitleFrench = "Journaux d'audit",
                    Icon = "fa-solid fa-clipboard-list",
                    Url = "/internal/audit-logs",
                    DisplayOrder = 4,
                    ParentId = 10,
                    Role = "Staff"
                },
                new MenuItem
                {
                    Id = 15,
                    Title = "Draft Analytics",
                    TitleFrench = "Analytique des brouillons",  
                    Icon = "fa-solid fa-chart-line",
                    Url = "/internal/draft-analytics",
                    DisplayOrder = 5,
                    ParentId = 10,
                    Role = "Staff"
                },

                // Executive Menu (Parent)
                new MenuItem
                {
                    Id = 20,
                    Title = "Executive",
                    TitleFrench = "Direction",
                    Icon = "fa-solid fa-user-tie",
                    Url = "#",
                    DisplayOrder = 20,
                    Role = "Executive"
                },

                // Executive Children
                new MenuItem
                {
                    Id = 21,
                    Title = "Oversight Dashboard",
                    TitleFrench = "Tableau de bord de surveillance",
                    Icon = "fa-solid fa-chart-pie",
                    Url = "/executive/oversight",
                    DisplayOrder = 1,
                    ParentId = 20,
                    Role = "Executive"
                },
                new MenuItem
                {
                    Id = 22,
                    Title = "Heatmaps",
                    TitleFrench = "Cartes de chaleur",
                    Icon = "fa-solid fa-fire",
                    Url = "/internal/draft-heatmap",
                    DisplayOrder = 2,
                    ParentId = 20,
                    Role = "Executive"
                },
                new MenuItem
                {
                    Id = 23,
                    Title = "Suspicious Activity",
                    TitleFrench = "Activité suspecte",
                    Icon = "fa-solid fa-shield-halved",
                    Url = "/regulator/suspicious-activity",
                    DisplayOrder = 3,
                    ParentId = 20,
                    Role = "Executive"
                },
                new MenuItem
                {
                    Id = 24,
                    Title = "Device Security Reports",
                    TitleFrench = "Rapports de sécurité des appareils",
                    Icon = "fa-solid fa-mobile-screen",
                    Url = "/regulator/device-security",
                    DisplayOrder = 4,
                    ParentId = 20,
                    Role = "Executive"
                },
                new MenuItem
                {
                    Id = 25,
                    Title = "UX Optimization Report",
                    TitleFrench = "Rapport d'optimisation UX",
                    Icon = "fa-solid fa-lightbulb",
                    Url = "/internal/ux-report",
                    DisplayOrder = 5,
                    ParentId = 20,
                    Role = "Executive"
                }
            );
        }
    }
}


//•	Either run both updates (specify the startup project) or let your deployment run dotnet ef database update per context.
//# project that contains DbContext (infrastructure) is -p; startup (API) is -s

//    # Select 'Default project' = eGUCE.Infrastructure in PMC
//Add-Migration AddCoreDomainEntities
//Update-Database

/*  COMMANDS TO RUN IN TERMINAL EF CORE MIGRATIONS:
 *  
1.# from solution root - CoAntiCorDbContext (project that defines the context = -p)
dotnet ef migrations add Initial_EGuce \
  -c CoAntiCorDbContext \
  -p eGUCE.Infrastructure \
  -s CoAntiCor.API \
  -o Infrastructure/Migrations/EGuce

2.# ApplicationDbContext (adjust project names as needed)
dotnet ef migrations add Initial_App \
  -c ApplicationDbContext \
  -p CoAntiCor.API \
  -s CoAntiCor.API \
  -o API/Migrations/Application

dotnet ef database update -c CoAntiCorDbContext -p eGUCE.Infrastructure -s CoAntiCor.API
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
Add-Migration InitialIdentity -Context ApplicationDbContext -StartupProject CoAntiCor.API -OutputDir "Data/Migrations/Identity"

Add-Migration InitialDomain -Context CoAntiCorDbContext -StartupProject CoAntiCor.API -OutputDir "Data/Migrations/Domain"

Migrations/Identity/xxxx_InitialIdentity.cs
Migrations/Domain/xxxx_InitialDomain.cs

2. If DbContexts are in DIFFERENT projects (recommended architecture)

/CoAntiCor.API                ← Startup project
/eGUCE.APP           ← Contains ApplicationDbContext
/eGUCE.Infrastructure     ← Contains CoAntiCorDbContext

Commands:

Add-Migration InitialIdentity `
    -Context ApplicationDbContext `
    -Project eGUCE.Identity `
    -StartupProject CoAntiCor.API `
    -OutputDir "Migrations"

Add-Migration InitialDomain `
    -Context CoAntiCorDbContext `
    -Project eGUCE.Infrastructure `
    -StartupProject CoAntiCor.API `
    -OutputDir "Migrations"

This ensures:

Identity migrations go into eGUCE.Identity/Migrations

Domain 

///////////////////////////////////////
///
PM> Add-Migration InitialDomain -Context CoAntiCorDbContext -StartupProject CoAntiCor.API -OutputDir "Data/Migrations/Domain"
PM> Update-Database -Context CoAntiCorDbContext -StartupProject CoAntiCor.API
 
PM> Add-Migration InitialIdentity -Context ApplicationDbContext -StartupProject CoAntiCor.API -OutputDir "Data/Migrations/Identity"
PM> Update-Database -Context ApplicationDbContext -StartupProject CoAntiCor.API

PM> Remove-Migration -Context ApplicationDbContext -StartupProject CoAntiCor.API

 PM> Add-Migration AddedMenuAndNewEntity -Context CoAntiCorDbContext -StartupProject CoAntiCor.API -OutputDir "Data/Migrations/Domain"
PM> Update-Database -Context CoAntiCorDbContext -StartupProject CoAntiCor.API

PM> Add-Migration AddedServiceRequestEventAndNewEntity -Context CoAntiCorDbContext -StartupProject CoAntiCor.API -OutputDir "Data/Migrations/Domain"
 */