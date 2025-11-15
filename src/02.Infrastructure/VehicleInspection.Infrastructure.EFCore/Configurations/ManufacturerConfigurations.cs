using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleInspection.Domain.Core.ManufacturerAgg.Entities;

namespace VehicleInspection.Infrastructure.EFCore.Configurations
{
    public class ManufacturerConfigurations : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.ToTable("Manufacturers");

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).HasMaxLength(50).IsRequired();
            builder.HasMany(m => m.Cars).WithOne(c => c.Manufacturer).HasForeignKey(c => c.ManufacturerId);

            builder.HasData(new List<Manufacturer>
            {
                new Manufacturer { Id = 1, Name = "ایران خودرو" },
                new Manufacturer { Id = 2, Name = "سایپا" },
            });
        }
    }
}