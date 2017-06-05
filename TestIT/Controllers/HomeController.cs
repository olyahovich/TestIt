using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace TestIT.Web.Controllers
{
    [SwaggerIgnore]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Home";
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }

}
