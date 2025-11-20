using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehicleInspection.Domain.Core.CarAgg.Contracts;
using VehicleInspection.Domain.Core.CarAgg.Dtos;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Contracts;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Dtos;
using VehicleInspection.Domain.Core.ManufacturerAgg.Contracts;
using VehicleInspection.Domain.Core.ManufacturerAgg.Dtos;
using VehicleInspection.Framework;
using VehicleInspection.Presentation.RazorPages.Models;

namespace VehicleInspection.Presentation.RazorPages.Pages.Inspection
{
    public class AddInspectionModel : PageModel
    {
        private readonly ICarAppService _carService;
        private readonly IManufacturerAppService _manufacturerService;
        private readonly IInspectionRequestAppService _service;

        public AddInspectionModel(
            ICarAppService carService,
            IInspectionRequestAppService service,
            IManufacturerAppService manufacturerService)
        {
            _carService = carService;
            _service = service;
            _manufacturerService = manufacturerService;
            Input = new InspectionRequestInputDto();
        }

        [BindProperty]
        public IranianPlateInput Plate { get; set; } = new();

        [BindProperty]
        public InspectionRequestInputDto Input { get; set; }

        [BindProperty]
        public string ShamsiVisitAt { get; set; } // تاریخ شمسی از کاربر

        public List<ManufacturerDto> Factories { get; set; } = new();
        public List<CarDto> Cars { get; set; } = new();

        // اولین بار که صفحه باز میشه یا وقتی کارخانه عوض میشه
        public void OnGet(int? factoryId = null)
        {
            Factories = _manufacturerService.GetManufacturer();

            if (factoryId.HasValue && factoryId.Value > 0)
            {
                Input.CarManufactureId = factoryId.Value;
                Cars = _carService.GetCarList(factoryId.Value);
            }
        }

        // این متد خیلی مهمه! وقتی کارخانه عوض میشه این صدا میشه (با GET نه POST)
        public IActionResult OnGetLoadCars(int factoryId)
        {
            Factories = _manufacturerService.GetManufacturer();
            Input.CarManufactureId = factoryId;

            if (factoryId > 0)
                Cars = _carService.GetCarList(factoryId);

            return Page(); // صفحه رو دوباره رندر می‌کنه ولی با GET
        }

        public IActionResult OnPost()
        {
            // اول از همه: پلاک رو بساز (این خط حتماً اول باشه!)
            Input.CarPlateNumber = Plate.ToPlateString();

            // تبدیل تاریخ شمسی (حتی اگه خالی باشه خطا می‌دیم)
            if (string.IsNullOrWhiteSpace(ShamsiVisitAt))
            {
                ModelState.AddModelError("ShamsiVisitAt", "تاریخ مراجعه الزامی است");
            }
            else
            {
                try
                {
                    Input.VisitAt = ShamsiVisitAt.ToGregorianDateOnly();
                }
                catch
                {
                    ModelState.AddModelError("ShamsiVisitAt", "تاریخ وارد شده معتبر نیست");
                }
            }

            // حالا ولیدیشن رو چک کن
            if (!ModelState.IsValid)
            {
                // دوباره لیست کارخانه و ماشین رو پر کن
                Factories = _manufacturerService.GetManufacturer();
                if (Input.CarManufactureId > 0)
                    Cars = _carService.GetCarList(Input.CarManufactureId);

                return Page();
            }

            // همه چیز اوکی → ذخیره کن
            var result = _service.AddInspectionRequest(Input);

            if (result.IsSuccess)
            {
                return RedirectToPage("Success", new { message = result.Message });
            }
            else
            {
                return RedirectToPage("Failed", new { message = result.Message });
            }
        }
    }
}