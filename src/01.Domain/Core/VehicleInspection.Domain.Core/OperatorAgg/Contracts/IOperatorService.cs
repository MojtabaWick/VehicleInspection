using VehicleInspection.Domain.Core.OperatorAgg.Dtos;

namespace VehicleInspection.Domain.Core.OperatorAgg.Contracts
{
    public interface IOperatorService
    {
        public OperatorDto? LogIn(string username, string password);
    }
}