using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Entities;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Enums;

namespace VehicleInspection.Infrastructure.EFCore.Configurations
{
    internal class DeniedInspectionRequestConfigurations : IEntityTypeConfiguration<DeniedInspectionRequest>
    {
        public void Configure(EntityTypeBuilder<DeniedInspectionRequest> builder)
        {
            builder.ToTable("DeniedInspectionRequests");
            builder.HasKey(di => di.Id);
            builder.Property(di => di.CarOwnerName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(di => di.CarOwnerPhoneNumber)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(di => di.CarOwnerIdCardNumber)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(di => di.CarPlateNumber)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(di => di.ManufactureYear)
                .IsRequired()
                .HasMaxLength(4);

            builder.Property(di => di.IsHybridFuel)
                .IsRequired();

            builder.Property(di => di.IsAutomatic)
                .IsRequired();

            builder.Property(di => di.Address)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(di => di.Status)
                .HasConversion<string>()
                .HasDefaultValue(InspectionStatus.NotAllowed);
        }
    }
}