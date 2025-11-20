using System.ComponentModel.Design;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Dtos;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Entities;

namespace VehicleInspection.Domain.Core.InspectionRequestAgg.Contracts
{
    public interface IInspectionRequestService
    {
        public bool IsCarAllowedInDate(int carManufacturerId, DateOnly date);

        public bool IsCarFiveYearsOLd(int carManufacturerYear);

        public bool IsQueueFull(DateOnly date);

        public bool AddInspectionRequest(InspectionRequestInputDto input);

        public List<InspectionRequestShowDto> GetInspectionRequestShowList(DateOnly? date, int? manufacturerId);

        public void SetPending(int inspectionId);

        public void SetApproved(int inspectionId);

        public void SetRejected(int inspectionId);

        public void SetNotAllowed(int inspectionId);
    }
}