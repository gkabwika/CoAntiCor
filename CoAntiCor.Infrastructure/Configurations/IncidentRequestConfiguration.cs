using CoAntiCor.Core.Domain.ServiceRequest;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Infrastructure.Configurations;

public class IncidentRequestConfiguration : IEntityTypeConfiguration<IncidentRequest>
{
    public void Configure(EntityTypeBuilder<CoAntiCor.Core.Domain.ServiceRequest.IncidentRequest> builder)
    {
        builder.ToTable("IncidentRequests");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.IncidentNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(x => x.IncidentNumber)
            .IsUnique();

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(4000);

        builder.Property(x => x.IncidentTypeOther)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Category)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Province)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.City)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.Commune)
           .IsRequired()
           .HasMaxLength(100);
        builder.Property(x => x.Quartier)
           .IsRequired()
           .HasMaxLength(100);
        builder.Property(x => x.Address)
           .IsRequired()
           .HasMaxLength(100);

        builder.Property(x => x.CitizenName)
            .HasMaxLength(200);

        builder.Property(x => x.CitizenEmail)
            .HasMaxLength(200);

        builder.Property(x => x.CitizenPhone)
            .HasMaxLength(50);

        builder.Property(x => x.Status)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.HasMany(x => x.EvidenceFiles)
            .WithOne()
            .HasForeignKey(e => e.IncidentRequestId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.PhaseHistory)
            .WithOne()
            .HasForeignKey(h => h.IncidentRequestId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class IncidentEvidenceConfiguration : IEntityTypeConfiguration<IncidentEvidence>
{
    public void Configure(EntityTypeBuilder<IncidentEvidence> builder)
    {
        builder.ToTable("IncidentEvidence");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FileName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.ContentType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.StoragePath)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.SizeBytes)
            .IsRequired();

        builder.Property(x => x.UploadedAt)
            .IsRequired();
    }
}

public class ProcessingPhaseHistoryConfiguration : IEntityTypeConfiguration<ProcessingPhaseHistory>
{
    public void Configure(EntityTypeBuilder<ProcessingPhaseHistory> builder)
    {
        builder.ToTable("ProcessingPhaseHistory");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Phase)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Notes)
            .HasMaxLength(2000);

        builder.Property(x => x.Status)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.ChangedAt)
            .IsRequired();
    }
}

