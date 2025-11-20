using VehicleInspection.Domain.Core.CarAgg.Dtos;

namespace VehicleInspection.Domain.Core.CarAgg.Contracts
{
    public interface ICarAppService
    {
        public List<CarDto> GetCarList(int manufacturerId);
    }
}