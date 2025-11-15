using VehicleInspection.Domain.Core._common;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Entities;
using VehicleInspection.Domain.Core.ManufacturerAgg.Entities;

namespace VehicleInspection.Domain.Core.CarAgg.Entities
{
    public class Car : BaseEntity
    {
        public string Name { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }
        public List<InspectionRequest> InspectionRequests { get; set; } = [];
    }
}