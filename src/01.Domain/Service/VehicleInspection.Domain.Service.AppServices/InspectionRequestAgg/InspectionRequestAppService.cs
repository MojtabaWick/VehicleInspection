using VehicleInspection.Domain.Core._common;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Contracts;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Dtos;

namespace VehicleInspection.Domain.Service.AppServices.InspectionRequestAgg
{
    public class InspectionRequestAppService(IInspectionRequestService inspectionService, IDeniedInspectionRequestService deniedInspectionService) : IInspectionRequestAppService
    {
        public Result<bool> AddInspectionRequest(InspectionRequestInputDto input)
        {
            if (!inspectionService.IsCarAllowedInDate(input.CarManufactureId, input.VisitAt))
            {
                return Result<bool>.Failure("ماشین در این تاریخ نمیتواند بازدید شود.");
            }

            if (inspectionService.IsCarFiveYearsOLd(input.ManufactureYear))
            {
                deniedInspectionService.Add(input);
                return Result<bool>.Failure("سال ساخت ماشین بیشتر از 5 سال است ، از پذیرش آن معذوریم.");
            }

            if (inspectionService.IsQueueFull(input.VisitAt))
            {
                return Result<bool>.Failure("در تاریخ انتخابی نوبت خالی نمیباشد.");
            }

            if (input.CarPlateNumber is not null)
            {
                var addResult = inspectionService.AddInspectionRequest(input);
                if (addResult)
                {
                    return Result<bool>.Success("درخواست با موفقیت ثبت شد.");
                }
                else
                {
                    return Result<bool>.Failure("در ثبت درخواست خطایی رخ داده است.");
                }
            }

            if (input.CarPlateNumber is null)
            {
                return Result<bool>.Failure("لطفا شماره پلاک را درست وارد کنید.");
            }

            return Result<bool>.Failure("سیستم با خطا مواجه شده است.");
        }

        public List<InspectionRequestShowDto> GetInspectionRequests(DateOnly? date, int? manufacturerId)
        {
            return inspectionService.GetInspectionRequestShowList(date, manufacturerId);
        }

        public void SetPending(int inspectionId) => inspectionService.SetPending(inspectionId);

        public void SetApproved(int inspectionId) => inspectionService.SetApproved(inspectionId);

        public void SetRejected(int inspectionId) => inspectionService.SetRejected(inspectionId);

        public void SetNotAllowed(int inspectionId) => inspectionService.SetNotAllowed(inspectionId);
    }
}