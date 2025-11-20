using VehicleInspection.Domain.Core.ManufacturerAgg.Dtos;

namespace VehicleInspection.Domain.Core.ManufacturerAgg.Contracts
{
    public interface IManufacturerRepository
    {
        public List<ManufacturerDto> GetManufacturerDto();
    }
}