using VehicleInspection.Domain.Core.ManufacturerAgg.Dtos;

namespace VehicleInspection.Domain.Core.ManufacturerAgg.Contracts
{
    public interface IManufacturerAppService
    {
        public List<ManufacturerDto> GetManufacturer();
    }
}