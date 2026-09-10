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
    public class IncidentSecurityDetailConfiguration : IEntityTypeConfiguration<IncidentSecurityDetail>
    {
        public void Configure(EntityTypeBuilder<IncidentSecurityDetail> builder)
        {
            builder.ToTable("IncidentSecurityDetails");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.HasOne(x => x.IncidentRequest)
                .WithOne() // or .WithMany(r => r.SecurityDetails) if you want multiple
                .HasForeignKey<IncidentSecurityDetail>(x => x.IncidentRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.DeviceId).HasMaxLength(256);
            builder.Property(x => x.DeviceModel).HasMaxLength(256);
            builder.Property(x => x.DeviceManufacturer).HasMaxLength(256);
            builder.Property(x => x.DeviceOS).HasMaxLength(128);
            builder.Property(x => x.DeviceOSVersion).HasMaxLength(64);
            builder.Property(x => x.BrowserName).HasMaxLength(128);
            builder.Property(x => x.BrowserVersion).HasMaxLength(64);
            builder.Property(x => x.UserAgentString).HasMaxLength(1024);
            builder.Property(x => x.ScreenResolution).HasMaxLength(64);

            builder.Property(x => x.IpAddress).HasMaxLength(64);
            builder.Property(x => x.IpAddressOriginCountry).HasMaxLength(128);
            builder.Property(x => x.IpAddressOriginCity).HasMaxLength(128);
            builder.Property(x => x.IpAddressOriginISP).HasMaxLength(256);
            builder.Property(x => x.NetworkType).HasMaxLength(64);

            builder.Property(x => x.GeoCountry).HasMaxLength(128);
            builder.Property(x => x.GeoCity).HasMaxLength(128);
            builder.Property(x => x.GeoRegion).HasMaxLength(128);

            builder.Property(x => x.MouseMovementPatternHash).HasMaxLength(256);
            builder.Property(x => x.TouchPressurePatternHash).HasMaxLength(256);

            builder.Property(x => x.SessionId).HasMaxLength(256);
            builder.Property(x => x.RiskLevel).HasMaxLength(32);

            builder.Property(x => x.Language).HasMaxLength(32);
            builder.Property(x => x.Platform).HasMaxLength(64);
            builder.Property(x => x.ReferrerUrl).HasMaxLength(512);
            builder.Property(x => x.EntryUrl).HasMaxLength(512);
        }
    }

}
