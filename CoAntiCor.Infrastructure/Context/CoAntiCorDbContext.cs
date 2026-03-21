using CoAntiCor.Core.Domain;
using CoAntiCor.Core.Model;
using CoAntiCor.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

            modelBuilder.Entity<ComplaintNumberSequence>().HasData(
            new ComplaintNumberSequence
            {
                Id = 1,
                Year = DateTime.UtcNow.Year,
                LastNumber = 0
            });

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

            modelBuilder.Entity<AuditLog>()
       .HasIndex(a => a.TimestampUtc);

            modelBuilder.Entity<AuditLog>()
                .HasIndex(a => new { a.EntityType, a.EntityId });

            // Additional configuration as needed
        }
    }
}
