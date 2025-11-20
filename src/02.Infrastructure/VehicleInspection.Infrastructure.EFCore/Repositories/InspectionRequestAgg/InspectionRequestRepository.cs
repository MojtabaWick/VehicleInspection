using Microsoft.EntityFrameworkCore;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Contracts;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Dtos;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Entities;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Enums;
using VehicleInspection.Infrastructure.EFCore.Persistence;

namespace VehicleInspection.Infrastructure.EFCore.Repositories.InspectionRequestAgg
{
    public class InspectionRequestRepository(AppDbContext dbContext) : IInspectionRequestRepository
    {
        public bool Add(InspectionRequest request)
        {
            dbContext.InspectionRequests.Add(request);
            return dbContext.SaveChanges() > 0;
        }

        public bool IsPlateNumExist(string plateNumber)
        {
            return dbContext.InspectionRequests.Any(i => i.CarPlateNumber == plateNumber);
        }

        public List<InspectionRequestShowDto> GetList(DateOnly? date, int? manufacturerId)
        {
            var query = dbContext.InspectionRequests
                .Include(i => i.Car)
                .AsQueryable();

            if (date is not null)
                query = query.Where(i => i.VisitAt == date);

            if (manufacturerId is not null)
                query = query.Where(i => i.Car.ManufacturerId == manufacturerId);

            return query
                .Select(i => new InspectionRequestShowDto
                {
                    Id = i.Id,
                    Status = i.Status,
                    VisitAt = i.VisitAt,
                    CarOwnerPhoneNumber = i.CarOwnerPhoneNumber,
                    QueueNumber = i.QueueNumber,
                    Address = i.Address,
                    CarName = i.Car.Name,
                    CarManufacturerId = i.Car.ManufacturerId,
                    CarOwnerIdCardNumber = i.CarOwnerIdCardNumber,
                    CarOwnerName = i.CarOwnerName,
                    CarPlateNumber = i.CarPlateNumber,
                    IsAutomatic = i.IsAutomatic,
                    IsHybridFuel = i.IsHybridFuel,
                    ManufactureYear = i.ManufactureYear,
                })
                .ToList();
        }

        public int GetLastQueueNumber(DateOnly date)
        {
            return dbContext.InspectionRequests.Count(i => i.VisitAt == date);
        }

        public void SetPending(int inspectionId)
        {
            dbContext.InspectionRequests
                .Where(i => i.Id == inspectionId)
                .ExecuteUpdate(setter => setter
                    .SetProperty(i => i.Status, InspectionStatus.Pending)
                );
        }

        public void SetApproved(int inspectionId)
        {
            dbContext.InspectionRequests
                .Where(i => i.Id == inspectionId)
                .ExecuteUpdate(setter => setter
                    .SetProperty(i => i.Status, InspectionStatus.Approved)
                );
        }

        public void SetRejected(int inspectionId)
        {
            dbContext.InspectionRequests
                .Where(i => i.Id == inspectionId)
                .ExecuteUpdate(setter => setter
                    .SetProperty(i => i.Status, InspectionStatus.Rejected)
                );
        }

        public void SetNotAllowed(int inspectionId)
        {
            dbContext.InspectionRequests
                .Where(i => i.Id == inspectionId)
                .ExecuteUpdate(setter => setter
                    .SetProperty(i => i.Status, InspectionStatus.NotAllowed)
                );
        }
    }
}