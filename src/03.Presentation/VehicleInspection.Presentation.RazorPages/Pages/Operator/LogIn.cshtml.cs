using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehicleInspection.Domain.Core.CarAgg.Contracts;
using VehicleInspection.Domain.Core.OperatorAgg.Contracts;
using VehicleInspection.Domain.Core.OperatorAgg.Dtos;
using VehicleInspection.Presentation.RazorPages.InMemoryDataBase;
using VehicleInspection.Presentation.RazorPages.Models;

namespace VehicleInspection.Presentation.RazorPages.Pages.Operator
{
    public class LogInModel : PageModel
    {
        private readonly IOperatorAppService _operatorAppService;

        public LogInModel(IOperatorAppService service)
        {
            _operatorAppService = service;
        }

        public string ResultMessage { get; set; }

        [BindProperty]
        public OperatorLogInInputDto Operator { get; set; } = new OperatorLogInInputDto();

        public void OnGet(string message)
        {
            ResultMessage = message;
        }

        public IActionResult OnPost()
        {
            var loginResult = _operatorAppService.LogIn(Operator.Username, Operator.Password);

            if (loginResult.IsSuccess)
            {
                InMemoryDB.OnlineUser = new OnlineUser
                {
                    Id = loginResult.Data.Id,
                    Username = loginResult.Data.Username
                };

                return RedirectToPage("/Operator/InspectionList");
            }

            return RedirectToPage("/Operator/LogIn", new { message = loginResult.Message });
        }
    }
}