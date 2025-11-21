using System.ComponentModel.DataAnnotations;

namespace VehicleInspection.Domain.Core.InspectionRequestAgg.Dtos
{
    public class InspectionRequestInputDto
    {
        [Required(ErrorMessage = "انتخاب خودرو الزامی است")]
        public int CarId { get; set; }

        public int CarManufactureId { get; set; }

        [Required(ErrorMessage = "نام مالک را وارد کنید")]
        public string CarOwnerName { get; set; }

        [Required(ErrorMessage = "شماره تلفن الزامی است")]
        public string CarOwnerPhoneNumber { get; set; }

        [Required(ErrorMessage = "کد ملی الزامی است")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "کد ملی باید ۱۰ رقم باشد")]
        public string CarOwnerIdCardNumber { get; set; }

        public string? CarPlateNumber { get; set; }

        [Range(1300, 1500, ErrorMessage = "سال ساخت معتبر نیست")]
        public int ManufactureYear { get; set; }

        public bool IsHybridFuel { get; set; }
        public bool IsAutomatic { get; set; }

        [Required(ErrorMessage = "آدرس الزامی است")]
        public string Address { get; set; }

        [Required(ErrorMessage = "تاریخ مراجعه را انتخاب کنید")]
        public DateOnly VisitAt { get; set; }

        public List<string> Images { get; set; } = [];
    }
}