using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleInspection.Domain.Core.CarAgg.Entities;

namespace VehicleInspection.Infrastructure.EFCore.Configurations
{
    internal class CarConfigurations : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasOne(c => c.Manufacturer)
                   .WithMany(m => m.Cars)
                   .HasForeignKey(c => c.ManufacturerId);

            builder.HasMany(c => c.InspectionRequests)
                   .WithOne(ir => ir.Car)
                   .HasForeignKey(ir => ir.CarId);

            #region SeedData

            builder.HasData(new List<Car>
            {
                new Car { Id = 1, Name = "پژو 206 تیپ 2", ManufacturerId = 1 },
                new Car { Id = 2, Name = "پژو 206 تیپ 5", ManufacturerId = 1 },
                new Car { Id = 3, Name = "پژو 206 صندوقدار (V20 – V8)", ManufacturerId = 1 },
                new Car { Id = 4, Name = "پژو 207", ManufacturerId = 1 },
                new Car { Id = 5, Name = "پژو 207 پانوراما", ManufacturerId = 1 },
                new Car { Id = 6, Name = "پژو 405 GLX", ManufacturerId = 1 },
                new Car { Id = 7, Name = "پژو 405 SLX", ManufacturerId = 1 },
                new Car { Id = 8, Name = "پژو پارس (پارس معمولی)", ManufacturerId = 1 },
                new Car { Id = 9, Name = "پارس LX", ManufacturerId = 1 },
                new Car { Id = 10, Name = "پارس TU5", ManufacturerId = 1 },
                new Car { Id = 11, Name = "پارس XU7P", ManufacturerId = 1 },
                new Car { Id = 12, Name = "سمند LX", ManufacturerId = 1 },
                new Car { Id = 13, Name = "سمند EF7", ManufacturerId = 1 },
                new Car { Id = 14, Name = "سورن ELX", ManufacturerId = 1 },
                new Car { Id = 15, Name = "سورن پلاس", ManufacturerId = 1 },
                new Car { Id = 16, Name = "دنا", ManufacturerId = 1 },
                new Car { Id = 17, Name = "دنا پلاس ‌", ManufacturerId = 1 },
                new Car { Id = 18, Name = "دنا پلاس توربو‌", ManufacturerId = 1 },
                new Car { Id = 19, Name = "رانا", ManufacturerId = 1 },
                new Car { Id = 20, Name = "رانا پلاس", ManufacturerId = 1 },
                new Car { Id = 21, Name = "رانا پلاس پانوراما", ManufacturerId = 1 },
                new Car { Id = 22, Name = "تارا", ManufacturerId = 1 },
                new Car { Id = 23, Name = "هایما S5", ManufacturerId = 1 },
                new Car { Id = 24, Name = "هایما S7", ManufacturerId = 1 },
                new Car { Id = 25, Name = "اچ‌سی کراس (H30 Cross)", ManufacturerId = 1 },
                new Car { Id = 26, Name = "رانا LX (مدل‌های قدیمی)", ManufacturerId = 1 },
                new Car { Id = 27, Name = "پراید 111", ManufacturerId = 2 },
                new Car { Id = 28 , Name = "پراید 131", ManufacturerId = 2},
                new Car { Id = 29 , Name = "پراید 132", ManufacturerId = 2},
                new Car { Id = 30 , Name = "پراید 141", ManufacturerId = 2},
                new Car { Id = 31 , Name = "پراید 151 (وانت)", ManufacturerId = 2},
                new Car { Id = 32 , Name = "تیبا صندوقدار", ManufacturerId = 2},
                new Car { Id = 33 , Name = "تیبا 2 (هاچبک)", ManufacturerId = 2},
                new Car { Id = 34 , Name = "ساینا معمولی", ManufacturerId = 2},
                new Car { Id = 35 , Name = "ساینا S (Sکلاس)", ManufacturerId = 2},
                new Car { Id = 36 , Name = "ساینا اتومات (قدیمی)", ManufacturerId = 2},
                new Car { Id = 37 , Name = "کوییک", ManufacturerId = 2},
                new Car { Id = 38 , Name = "کوییک R دو رنگ", ManufacturerId = 2},
                new Car { Id = 39 , Name = "کوییک S", ManufacturerId = 2},
                new Car { Id = 40 , Name = "شاهین S", ManufacturerId = 2},
                new Car { Id = 41 , Name = "شاهین G", ManufacturerId = 2},
                new Car { Id = 42 , Name = "آریا (نسل جدید – کراس اور)", ManufacturerId = 2},
            });

            #endregion SeedData
        }
    }
}