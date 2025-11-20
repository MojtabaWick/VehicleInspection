using System;
using System.Collections.Generic;
using System.Text;
using VehicleInspection.Domain.Core.OperatorAgg.Contracts;
using VehicleInspection.Domain.Core.OperatorAgg.Dtos;
using VehicleInspection.Infrastructure.EFCore.Persistence;

namespace VehicleInspection.Infrastructure.EFCore.Repositories.OperatorAgg
{
    public class OperatorRepository(AppDbContext dbContext) : IOperatorRepository
    {
        public OperatorDto? LogIn(string username, string password)
        {
            return dbContext.Operators
                .Where(o => o.Username == username && o.Password == password)
                .Select(o => new OperatorDto
                {
                    Id = o.Id,
                    Username = o.Username
                })
                .FirstOrDefault();
        }
    }
}