using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Contracts;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Dtos;
using VehicleInspection.Domain.Core.ManufacturerAgg.Contracts;
using VehicleInspection.Domain.Core.ManufacturerAgg.Dtos;
using VehicleInspection.Framework;
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

        [BindProperty(SupportsGet = true, Name = "selectedDate")]
        public DateOnly? SelectedDate { get; set; }

        [BindProperty(SupportsGet = true, Name = "manufacturerId")]
        public int? ManufacturerId { get; set; }

        public IActionResult OnGet()
        {
            if (InMemoryDB.OnlineUser == null)
                return RedirectToPage("/Operator/LogIn");

            Manufacturers = _manufacturerService.GetManufacturer();

            // ????? ????? ???? ?? ?????? ??? ????? ?????? ????
            DateOnly? gregorianDate = null;

            if (!string.IsNullOrWhiteSpace(Request.Query["selectedDate"]))
            {
                string shamsi = Request.Query["selectedDate"].ToString();
                gregorianDate = shamsi.ToGregorianDateOnly();  // ????? ?? ??????
            }

            Requests = _inspectionService.GetInspectionRequests(gregorianDate, ManufacturerId);

            return Page();
        }

        public IActionResult OnGetSetApproved(int taskId)
        {
            _inspectionService.SetApproved(taskId);
            return RedirectToPage(new { selectedDate = SelectedDate, manufacturerId = ManufacturerId });
        }

        public IActionResult OnGetSetPending(int taskId)
        {
            _inspectionService.SetPending(taskId);
            return RedirectToPage(new { selectedDate = SelectedDate, manufacturerId = ManufacturerId });
        }

        public IActionResult OnGetSetRejected(int taskId)
        {
            _inspectionService.SetRejected(taskId);
            return RedirectToPage(new { selectedDate = SelectedDate, manufacturerId = ManufacturerId });
        }
    }
}