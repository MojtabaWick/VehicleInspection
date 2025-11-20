using VehicleInspection.Domain.Core.InspectionRequestAgg.Entities;

namespace VehicleInspection.Domain.Core.InspectionRequestAgg.Contracts
{
    public interface IDeniedInspectionRequestRepository
    {
        public bool Add(DeniedInspectionRequest request);
    }
}