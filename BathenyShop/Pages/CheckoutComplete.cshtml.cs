using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BathenyShop.Pages
{
    public class CheckoutCompleteModel : PageModel
    {
        public void OnGet()
        {
            ViewData["Message"] = "Thank you for your order!";
        }
    }
}
