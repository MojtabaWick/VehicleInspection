using VehicleInspection.Domain.Core.InspectionRequestAgg.Contracts;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Entities;
using VehicleInspection.Infrastructure.EFCore.Persistence;

namespace VehicleInspection.Infrastructure.EFCore.Repositories.DeniedInspectionRequestAgg
{
    public class DeniedInspectionRequestRepository(AppDbContext dbContext) : IDeniedInspectionRequestRepository
    {
        public bool Add(DeniedInspectionRequest request)
        {
            dbContext.DeniedInspectionRequests.Add(request);
            return dbContext.SaveChanges() > 0;
        }
    }
}