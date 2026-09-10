using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    using CoAntiCor.Core.Domain.ServiceRequest;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
    using System.Text.Json;
namespace CoAntiCor.Infrastructure.Configurations
{ 
    public class ServiceRequestWorkflowStateConfiguration : IEntityTypeConfiguration<ServiceRequestWorkflowState>
    {
        public void Configure(EntityTypeBuilder<ServiceRequestWorkflowState> builder)
        {
            builder.ToTable("ServiceRequestWorkflowStates");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.LabelFr)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.LabelEn)
                .IsRequired()
                .HasMaxLength(200);

            // JSON conversion for Dictionary<int, DateTime>
            var dictConverter = new ValueConverter<Dictionary<int, DateTime>, string>(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => string.IsNullOrWhiteSpace(v)
                    ? new Dictionary<int, DateTime>()
                    : JsonSerializer.Deserialize<Dictionary<int, DateTime>>(v, (JsonSerializerOptions?)null)
                      ?? new Dictionary<int, DateTime>()
            );

            builder.Property(x => x.StepCompletedUtc)
                .HasConversion(dictConverter)
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.Version)
                .IsRequired();

            builder.Property(x => x.LastSavedUtc);

            builder.Property(x => x.IsSaving)
                .IsRequired();

            builder.HasIndex(x => x.DraftId);
            builder.HasIndex(x => x.Code);
        }
    }


}
