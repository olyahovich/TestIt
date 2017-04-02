using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace TestIT.Web.Controllers
{
    [SwaggerIgnore]
    public class PartialController : Controller
    {
        public IActionResult AboutComponent() => PartialView();

        public IActionResult AppComponent() => PartialView();

        public IActionResult ContactComponent() => PartialView();

        public IActionResult IndexComponent() => PartialView();

        public IActionResult LoginComponent() => PartialView();

        public IActionResult RegisterComponent() => PartialView();
    }
}
