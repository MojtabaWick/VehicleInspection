using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Contracts;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Dtos;
using VehicleInspection.Domain.Core.ManufacturerAgg.Contracts;
using VehicleInspection.Domain.Core.ManufacturerAgg.Dtos;
using VehicleInspection.Presentation.RazorPages.InMemoryDataBase;

namespace VehicleInspection.Presentation.RazorPages.Pages.Operator
{
    public class InspectionListModel : PageModel
    {
        private readonly IInspectionRequestAppService _inspectionService;
        private readonly IManufacturerAppService _manufacturerService;

        public InspectionListModel(IInspectionRequestAppService inspectionService, IManufacturerAppService manufacturerService)
        {
            _inspectionService = inspectionService;
            _manufacturerService = manufacturerService;
        }

        public List<InspectionRequestShowDto> Requests { get; set; }
        public List<ManufacturerDto> Manufacturers { get; set; }

        public IActionResult OnGet(DateOnly? selectedDate, int? manufacturerId)
        {
            if (InMemoryDB.OnlineUser == null)
                return RedirectToPage("/Operator/LogIn");

            Manufacturers = _manufacturerService.GetManufacturer();

            Requests = _inspectionService.GetInspectionRequests(selectedDate, manufacturerId);

            return Page();
        }

        public IActionResult OnGetSetApproved(int taskId)
        {
            _inspectionService.SetApproved(taskId);
            return RedirectToPage();
        }

        public IActionResult OnGetSetPending(int taskId)
        {
            _inspectionService.SetPending(taskId);
            return RedirectToPage();
        }

        public IActionResult OnGetSetRejected(int taskId)
        {
            _inspectionService.SetRejected(taskId);
            return RedirectToPage();
        }
    }
}