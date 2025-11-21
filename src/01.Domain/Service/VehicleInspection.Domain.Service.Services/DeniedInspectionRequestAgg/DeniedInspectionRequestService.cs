using VehicleInspection.Domain.Core.InspectionRequestAgg.Contracts;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Dtos;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Entities;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Enums;

namespace VehicleInspection.Domain.Service.Services.DeniedInspectionRequestAgg
{
    public class DeniedInspectionRequestService(IDeniedInspectionRequestRepository deniedInspectionRepo) : IDeniedInspectionRequestService
    {
        public bool Add(InspectionRequestInputDto input)
        {
            var deniedRequest = new DeniedInspectionRequest
            {
                Status = InspectionStatus.NotAllowed,
                Address = input.Address,
                CarId = input.CarId,
                CarOwnerIdCardNumber = input.CarOwnerIdCardNumber,
                CarOwnerName = input.CarOwnerName,
                CarOwnerPhoneNumber = input.CarOwnerPhoneNumber,
                CarPlateNumber = input.CarPlateNumber,
                IsAutomatic = input.IsAutomatic,
                IsHybridFuel = input.IsHybridFuel,
                ManufactureYear = input.ManufactureYear,
                Reason = "older then 5 years.",
                Images = input.Images,
            };

            return deniedInspectionRepo.Add(deniedRequest);
        }
    }
}