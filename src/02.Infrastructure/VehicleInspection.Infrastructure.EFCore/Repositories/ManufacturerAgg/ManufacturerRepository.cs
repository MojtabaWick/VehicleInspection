using System;
using System.Collections.Generic;
using System.Text;
using VehicleInspection.Domain.Core.ManufacturerAgg.Contracts;
using VehicleInspection.Domain.Core.ManufacturerAgg.Dtos;
using VehicleInspection.Infrastructure.EFCore.Persistence;

namespace VehicleInspection.Infrastructure.EFCore.Repositories.ManufacturerAgg
{
    public class ManufacturerRepository(AppDbContext dbContext) : IManufacturerRepository
    {
        public List<ManufacturerDto> GetManufacturerDto()
        {
            return dbContext.Manufacturers.Select(m => new ManufacturerDto
            {
                Id = m.Id,
                Name = m.Name,
            }).ToList();
        }
    }
}