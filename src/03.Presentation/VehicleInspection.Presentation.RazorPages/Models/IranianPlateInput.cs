using System.ComponentModel.DataAnnotations;

namespace VehicleInspection.Presentation.RazorPages.Models
{
    public class IranianPlateInput
    {
        [Required, StringLength(2)]
        public string TwoDigitsFirst { get; set; }

        [Required, StringLength(1)]
        public string Letter { get; set; }

        [Required, StringLength(3)]
        public string ThreeDigits { get; set; }

        [Required, StringLength(2)]
        public string IranCode { get; set; }

        public string ToPlateString()
        {
            return $"{TwoDigitsFirst} {Letter} {ThreeDigits} ایران {IranCode}";
        }
    }
}