using VehicleInspection.Domain.Core._common;
using VehicleInspection.Domain.Core.CarAgg.Entities;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Enums;

namespace VehicleInspection.Domain.Core.InspectionRequestAgg.Entities
{
    public class InspectionRequest : BaseEntity
    {
        public Car Car { get; set; }
        public int CarId { get; set; }
        public string CarOwnerName { get; set; }
        public string CarOwnerPhoneNumber { get; set; }
        public string CarOwnerIdCardNumber { get; set; }
        public string CarPlateNumber { get; set; }
        public int ManufactureYear { get; set; }
        public bool IsHybridFuel { get; set; }
        public bool IsAutomatic { get; set; }
        public int QueueNumber { get; set; }
        public string Address { get; set; }
        public InspectionStatus Status { get; set; }
        public DateOnly VisitAt { get; set; }
    }
}