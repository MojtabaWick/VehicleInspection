using VehicleInspection.Domain.Core._common;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Dtos;

namespace VehicleInspection.Domain.Core.InspectionRequestAgg.Contracts
{
    public interface IInspectionRequestAppService
    {
        public Result<bool> AddInspectionRequest(InspectionRequestInputDto input);

        public List<InspectionRequestShowDto> GetInspectionRequests(DateOnly? date, int? manufacturerId);

        public void SetPending(int inspectionId);

        public void SetApproved(int inspectionId);

        public void SetRejected(int inspectionId);

        public void SetNotAllowed(int inspectionId);
    }
}