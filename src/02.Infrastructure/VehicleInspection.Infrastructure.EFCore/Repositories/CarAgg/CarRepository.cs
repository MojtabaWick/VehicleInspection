using VehicleInspection.Domain.Core.CarAgg.Contracts;
using VehicleInspection.Domain.Core.CarAgg.Dtos;
using VehicleInspection.Infrastructure.EFCore.Persistence;

namespace VehicleInspection.Infrastructure.EFCore.Repositories.CarAgg
{
    public class CarRepository(AppDbContext dbContext) : ICarRepository
    {
        public List<CarDto> GetManufacturerCarsList(int manufacturerId)
        {
            return dbContext.Cars
                .Where(c => c.ManufacturerId == manufacturerId)
                .Select(c => new CarDto
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToList();
        }
    }
}