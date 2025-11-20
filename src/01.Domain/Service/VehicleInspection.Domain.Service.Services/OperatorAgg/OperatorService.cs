using Microsoft.Identity.Client;
using VehicleInspection.Domain.Core.OperatorAgg.Contracts;
using VehicleInspection.Domain.Core.OperatorAgg.Dtos;

namespace VehicleInspection.Domain.Service.Services.OperatorAgg
{
    public class OperatorService(IOperatorRepository operatorRepository) : IOperatorService
    {
        public OperatorDto? LogIn(string username, string password)
        {
            return operatorRepository.LogIn(username, password);
        }
    }
}