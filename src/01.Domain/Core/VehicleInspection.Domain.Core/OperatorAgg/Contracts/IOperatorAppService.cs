using VehicleInspection.Domain.Core._common;
using VehicleInspection.Domain.Core.OperatorAgg.Dtos;

namespace VehicleInspection.Domain.Core.OperatorAgg.Contracts
{
    public interface IOperatorAppService
    {
        public Result<OperatorDto> LogIn(string username, string password);
    }
}