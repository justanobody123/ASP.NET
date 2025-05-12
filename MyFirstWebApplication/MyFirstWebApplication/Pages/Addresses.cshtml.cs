using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyFirstWebApplication.Pages
{
    public class AddressesModel : PageModel
    {
        private readonly ILogger<AddressesModel> _logger;
        public AddressesModel(ILogger<AddressesModel> logger)
        {
            _logger = logger;

		}
        public void OnGet()
        {
           _logger.LogInformation("Пользователь перешел на страницу адресов ресторана.");
        }
    }
}
