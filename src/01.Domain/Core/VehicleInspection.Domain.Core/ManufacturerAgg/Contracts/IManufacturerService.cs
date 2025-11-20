using VehicleInspection.Domain.Core.ManufacturerAgg.Dtos;

namespace VehicleInspection.Domain.Core.ManufacturerAgg.Contracts
{
    public interface IManufacturerService
    {
        public List<ManufacturerDto> GetManufacturersList();
    }
}