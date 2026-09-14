using CoAntiCor.Core.Domain.ServiceRequest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Infrastructure.Configurations
{
    public class IncidentDetailConfiguration : IEntityTypeConfiguration<IncidentDetail>
    {
        public void Configure(EntityTypeBuilder<IncidentDetail> builder)
        {
            builder.ToTable("IncidentDetails");

            builder.HasKey(x => x.Id);

            builder.HasOne<IncidentRequest>()
                .WithOne(x => x.IncidentDetail)
                .HasForeignKey<IncidentDetail>(x => x.IncidentRequestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
