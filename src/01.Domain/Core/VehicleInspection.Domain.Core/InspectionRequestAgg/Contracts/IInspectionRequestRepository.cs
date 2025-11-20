using VehicleInspection.Domain.Core.InspectionRequestAgg.Dtos;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Entities;

namespace VehicleInspection.Domain.Core.InspectionRequestAgg.Contracts
{
    public interface IInspectionRequestRepository
    {
        public bool Add(InspectionRequest request);

        public bool IsPlateNumExist(string plateNumber);

        public List<InspectionRequestShowDto> GetList(DateOnly? date, int? manufacturerId);

        public int GetLastQueueNumber(DateOnly date);

        public void SetPending(int inspectionId);

        public void SetApproved(int inspectionId);

        public void SetRejected(int inspectionId);

        public void SetNotAllowed(int inspectionId);
    }
}