using Microsoft.AspNetCore.Mvc;

namespace PWF.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
