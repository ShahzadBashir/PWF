using Microsoft.AspNetCore.Mvc;
using PWF.Services;
using PWF.Services.Models;
using PWF.Services.PaymentGateway;

namespace PWF.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStripeService istripeService;
        public HomeController(IStripeService istripeService)
        {
            this.istripeService = istripeService;

        }
        public async Task<IActionResult> Charge()
        {

            var dd = await this.istripeService.CreateaCharge();

            //return View(dd);
            return View();
        }


        public IActionResult Index()
        {
            return View();
        }

    }
}
