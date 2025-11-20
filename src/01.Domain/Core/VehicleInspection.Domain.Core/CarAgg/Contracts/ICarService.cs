using VehicleInspection.Domain.Core.CarAgg.Dtos;

namespace VehicleInspection.Domain.Core.CarAgg.Contracts
{
    public interface ICarService
    {
        public List<CarDto> GetManufacturerCarList(int manufacturerID);
    }
}