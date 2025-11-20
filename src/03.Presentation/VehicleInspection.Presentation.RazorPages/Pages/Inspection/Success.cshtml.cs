using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VehicleInspection.Presentation.RazorPages.Pages.Inspection
{
    public class SuccessModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet(string message)
        {
            Message = message;
        }
    }
}