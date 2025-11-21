using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehicleInspection.Domain.Core.CarAgg.Contracts;
using VehicleInspection.Domain.Core.CarAgg.Dtos;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Contracts;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Dtos;
using VehicleInspection.Domain.Core.ManufacturerAgg.Contracts;
using VehicleInspection.Domain.Core.ManufacturerAgg.Dtos;
using VehicleInspection.Framework;
using VehicleInspection.Framework.FileService;
using VehicleInspection.Presentation.RazorPages.Models;

namespace VehicleInspection.Presentation.RazorPages.Pages.Inspection
{
    public class AddInspectionModel : PageModel
    {
        private readonly ICarAppService _carService;
        private readonly IManufacturerAppService _manufacturerService;
        private readonly IInspectionRequestAppService _service;
        private readonly IFileService _fileService;

        public AddInspectionModel(
            ICarAppService carService,
            IInspectionRequestAppService service,
            IManufacturerAppService manufacturerService,
            IFileService fileService)
        {
            _carService = carService;
            _service = service;
            _manufacturerService = manufacturerService;
            _fileService = fileService;
            Input = new InspectionRequestInputDto();
        }

        [BindProperty]
        public IranianPlateInput Plate { get; set; } = new();

        [BindProperty]
        public InspectionRequestInputDto Input { get; set; }

        [BindProperty]
        public List<IFormFile> Images { get; set; } = new();

        [BindProperty]
        public string ShamsiVisitAt { get; set; } // تاریخ شمسی از کاربر

        public List<ManufacturerDto> Factories { get; set; } = new();
        public List<CarDto> Cars { get; set; } = new();

        public void OnGet(int? factoryId = null)
        {
            Factories = _manufacturerService.GetManufacturer();

            if (factoryId.HasValue && factoryId.Value > 0)
            {
                Input.CarManufactureId = factoryId.Value;
                Cars = _carService.GetCarList(factoryId.Value);
            }
        }

        public IActionResult OnGetLoadCars(int factoryId)
        {
            Factories = _manufacturerService.GetManufacturer();
            Input.CarManufactureId = factoryId;

            if (factoryId > 0)
                Cars = _carService.GetCarList(factoryId);

            return Page();
        }

        public IActionResult OnPost()
        {
            Input.CarPlateNumber = Plate.ToPlateString();

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

            if (!ModelState.IsValid)
            {
                Factories = _manufacturerService.GetManufacturer();
                if (Input.CarManufactureId > 0)
                    Cars = _carService.GetCarList(Input.CarManufactureId);

                return Page();
            }

            List<string> images = new List<string>();

            if (Images != null || Images.Count > 0)
            {
                foreach (var file in Images)
                {
                    var image = _fileService.Upload(file, "CarImage");
                    images.Add(image);
                }
            }

            Input.Images.AddRange(images);

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