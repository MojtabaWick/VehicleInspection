using VehicleInspection.Domain.Core.InspectionRequestAgg.Dtos;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Entities;

namespace VehicleInspection.Domain.Core.InspectionRequestAgg.Contracts
{
    public interface IDeniedInspectionRequestService
    {
        public bool Add(InspectionRequestInputDto request);
    }
}