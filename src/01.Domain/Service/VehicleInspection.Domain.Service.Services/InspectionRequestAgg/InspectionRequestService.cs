using System.Globalization;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Contracts;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Dtos;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Entities;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Enums;
using VehicleInspection.Framework;

namespace VehicleInspection.Domain.Service.Services.InspectionRequestAgg
{
    public class InspectionRequestService(IInspectionRequestRepository inspectionRequestRepository) : IInspectionRequestService
    {
        public bool IsCarAllowedInDate(int carManufacturerId, DateOnly date)
        {
            if (carManufacturerId == 1)
                return date.IsEvenInspectionDay();

            if (carManufacturerId == 2)
                return !date.IsEvenInspectionDay();

            return false;
        }

        public bool IsCarFiveYearsOLd(int carManufacturerYear)
        {
            var pc = new PersianCalendar();

            int currentPersianYear = pc.GetYear(DateTime.Now);

            int age = currentPersianYear - carManufacturerYear;

            return age > 5;
        }

        public bool IsQueueFull(DateOnly date)
        {
            var lastQueueNumber = inspectionRequestRepository.GetLastQueueNumber(date);

            if (date.IsEvenInspectionDay())
                return lastQueueNumber >= 15;
            else
                return lastQueueNumber >= 10;
        }

        private int GenerateNewQueueNumber(DateOnly date)
        {
            var lastQueueNumber = inspectionRequestRepository.GetLastQueueNumber(date);
            return lastQueueNumber + 1;
        }

        public bool AddInspectionRequest(InspectionRequestInputDto input)
        {
            var newInspection = new InspectionRequest
            {
                Status = InspectionStatus.Pending,
                VisitAt = input.VisitAt,
                Address = input.Address,
                CarId = input.CarId,
                CarOwnerIdCardNumber = input.CarOwnerIdCardNumber,
                CarOwnerName = input.CarOwnerName,
                CarOwnerPhoneNumber = input.CarOwnerPhoneNumber,
                CarPlateNumber = input.CarPlateNumber,
                IsAutomatic = input.IsAutomatic,
                IsHybridFuel = input.IsHybridFuel,
                ManufactureYear = input.ManufactureYear,
                QueueNumber = GenerateNewQueueNumber(input.VisitAt),
            };

            return inspectionRequestRepository.Add(newInspection);
        }

        public List<InspectionRequestShowDto> GetInspectionRequestShowList(DateOnly? date, int? manufacturerId)
        {
            return inspectionRequestRepository.GetList(date, manufacturerId);
        }

        public void SetPending(int inspectionId) => inspectionRequestRepository.SetPending(inspectionId);

        public void SetApproved(int inspectionId) => inspectionRequestRepository.SetApproved(inspectionId);

        public void SetRejected(int inspectionId) => inspectionRequestRepository.SetRejected(inspectionId);

        public void SetNotAllowed(int inspectionId) => inspectionRequestRepository.SetNotAllowed(inspectionId);
    }
}