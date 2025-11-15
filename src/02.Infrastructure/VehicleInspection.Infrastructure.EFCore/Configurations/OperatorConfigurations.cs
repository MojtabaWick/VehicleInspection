using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleInspection.Domain.Core.OperatorAgg.Entities;

namespace VehicleInspection.Infrastructure.EFCore.Configurations
{
    internal class OperatorConfigurations : IEntityTypeConfiguration<Operator>
    {
        public void Configure(EntityTypeBuilder<Operator> builder)
        {
            builder.ToTable("Operators");
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Username)
                .HasMaxLength(50);

            builder.Property(o => o.Password)
                .HasMaxLength(40);

            builder.HasData(new List<Operator>()
            {
                new Operator{Id = 1 , Username = "Operator1" , Password = "Password1" , CreatedAt = new DateTime(2023, 1, 1) },
                new Operator{Id = 2 , Username = "Operator2" , Password = "Password2" , CreatedAt = new DateTime(2023, 1, 1) },
            });
        }
    }
}