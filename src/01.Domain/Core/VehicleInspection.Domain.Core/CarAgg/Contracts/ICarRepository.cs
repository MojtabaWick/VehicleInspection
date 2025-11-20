using VehicleInspection.Domain.Core.CarAgg.Dtos;

namespace VehicleInspection.Domain.Core.CarAgg.Contracts
{
    public interface ICarRepository
    {
        public List<CarDto> GetManufacturerCarsList(int manufacturerId);
    }
}