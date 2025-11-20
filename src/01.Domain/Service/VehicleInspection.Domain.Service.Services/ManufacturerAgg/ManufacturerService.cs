using VehicleInspection.Domain.Core.ManufacturerAgg.Contracts;
using VehicleInspection.Domain.Core.ManufacturerAgg.Dtos;

namespace VehicleInspection.Domain.Service.Services.ManufacturerAgg
{
    public class ManufacturerService(IManufacturerRepository manufacturerRepository) : IManufacturerService
    {
        public List<ManufacturerDto> GetManufacturersList()
        {
            return manufacturerRepository.GetManufacturerDto();
        }
    }
}