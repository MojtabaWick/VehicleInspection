using VehicleInspection.Domain.Core._common;
using VehicleInspection.Domain.Core.CarAgg.Entities;

namespace VehicleInspection.Domain.Core.ManufacturerAgg.Entities
{
    public class Manufacturer : BaseEntity
    {
        public string Name { get; set; }
        public List<Car> Cars { get; set; } = [];
    }
}