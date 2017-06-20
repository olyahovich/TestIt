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
        public IActionResult UsersComponent() => PartialView();
        public IActionResult ConfigurationsComponent() => PartialView();
        public IActionResult ForgotPasswordComponent() => PartialView();
        public IActionResult ProjectsComponent() => PartialView();
        public IActionResult ProfileComponent() => PartialView();
        public IActionResult ConfirmEmailComponent() => PartialView();
        public IActionResult ProjectTestRunsComponent() => PartialView();
        public IActionResult IndexComponent() => PartialView();
        public IActionResult LoginComponent() => PartialView();
        public IActionResult RegisterComponent() => PartialView();
        public IActionResult ManageComponent() => PartialView();
        public IActionResult ChangePasswordComponent() => PartialView();
    }
}
