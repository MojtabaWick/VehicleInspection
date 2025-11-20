using VehicleInspection.Domain.Core.CarAgg.Contracts;
using VehicleInspection.Domain.Core.CarAgg.Dtos;

namespace VehicleInspection.Domain.Service.Services.CarAgg
{
    public class CarService(ICarRepository carRepository) : ICarService
    {
        public List<CarDto> GetManufacturerCarList(int manufacturerID)
        {
            return carRepository.GetManufacturerCarsList(manufacturerID);
        }
    }
}