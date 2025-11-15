using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Entities;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Enums;

namespace VehicleInspection.Infrastructure.EFCore.Configurations
{
    internal class InspectionRequestConfigurations : IEntityTypeConfiguration<InspectionRequest>
    {
        public void Configure(EntityTypeBuilder<InspectionRequest> builder)
        {
            builder.ToTable("InspectionRequests");
            builder.HasKey(ir => ir.Id);

            builder.Property(ir => ir.CarOwnerName)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(ir => ir.CarOwnerPhoneNumber)
                   .IsRequired()
                   .HasMaxLength(15);

            builder.Property(ir => ir.CarOwnerIdCardNumber)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(ir => ir.CarPlateNumber)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(ir => ir.ManufactureYear)
                   .IsRequired()
                   .HasMaxLength(4);

            builder.Property(ir => ir.IsHybridFuel)
                .IsRequired();

            builder.Property(ir => ir.IsAutomatic)
                .IsRequired();

            builder.Property(ir => ir.QueueNumber)
                   .IsRequired()
                   .HasMaxLength(2);

            builder.Property(ir => ir.VisitAt)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(ir => ir.Address)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(ir => ir.Status)
                .HasConversion<string>()
                .HasDefaultValue(InspectionStatus.Pending);
        }
    }
}