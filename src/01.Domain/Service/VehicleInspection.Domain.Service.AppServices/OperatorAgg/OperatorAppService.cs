using VehicleInspection.Domain.Core._common;
using VehicleInspection.Domain.Core.OperatorAgg.Contracts;
using VehicleInspection.Domain.Core.OperatorAgg.Dtos;

namespace VehicleInspection.Domain.Service.AppServices.OperatorAgg
{
    public class OperatorAppService(IOperatorService operatorService) : IOperatorAppService

    {
        public Result<OperatorDto> LogIn(string username, string password)
        {
            var login = operatorService.LogIn(username, password);

            if (login is not null)
            {
                return Result<OperatorDto>.Success("لاگین با موفقیت انجام شد.", login);
            }

            return Result<OperatorDto>.Failure("نام کاربری یا کلمه عبور اشتباه می باشد.");
        }
    }
}