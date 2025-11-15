using Microsoft.EntityFrameworkCore;
using VehicleInspection.Domain.Core._common;
using VehicleInspection.Domain.Core.CarAgg.Entities;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Entities;
using VehicleInspection.Domain.Core.ManufacturerAgg.Entities;
using VehicleInspection.Domain.Core.OperatorAgg.Entities;

namespace VehicleInspection.Infrastructure.EFCore.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Operator> Operators { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<InspectionRequest> InspectionRequests { get; set; }
        public DbSet<DeniedInspectionRequest> DeniedInspectionRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ApplyAuditFields();
            return base.SaveChanges();
        }

        private void ApplyAuditFields()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.Now;
                        break;
                }
            }
        }
    }
}