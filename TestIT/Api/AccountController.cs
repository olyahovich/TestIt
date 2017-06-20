using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using TestIT.Data;
using TestIT.Entities;
using TestIT.Web.ViewModels;
using TestIT.Web.ViewModels.Account;

namespace TestIT.Web.Api
{
    [SwaggerIgnore]
    [Authorize]
    [RequireHttps]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly TestItContext _applicationDbContext;
        private static bool _databaseChecked;

        public AccountController(
            UserManager<User> userManager,
            IEmailSender emailSender,
            TestItContext applicationDbContext)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _applicationDbContext = applicationDbContext;
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User() { UserName = model.Email, Email = model.Email, CreatedOn = DateTime.UtcNow};
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action("Confirm", "Account",
                        new { email = user.Email, code }, HttpContext.Request.Scheme);
                    await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
                $"Please confirm your account by clicking this link: <a href='{callbackUrl}'>link</a>");
                    return Ok();
                }
                AddErrors(result);
            }

            // If we got this far, something failed.
            return BadRequest(ModelState);
        }
        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword([FromBody]ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var result = await _userManager.IsEmailConfirmedAsync(user);
                if (user == null || !result || await _userManager.IsLockedOutAsync(user))
                {
                    // Don't reveal that the user does not exist or is not confirmed.
                    return BadRequest(ModelState);
                }

                // Send an email with this link
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action(nameof(ResetPassword), "Account",
                    new { email = user.Email, code = code }, protocol: HttpContext.Request.Scheme);
                await _emailSender.SendEmailAsync(model.Email, "Reset Password",
                   $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");
                return Ok();
            }

            // If we got this far, something failed, redisplay form
            return BadRequest(ModelState);
        }

        #region Helpers
        [AllowAnonymous]
        [HttpGet("~/Account/Confirm", Name = "ConfirmEmail")]
        public async Task<IActionResult> Confirm(string email, string code)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || await _userManager.IsLockedOutAsync(user))
                return new BadRequestObjectResult($"Invalid email: {email}");

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (!result.Succeeded)
                return new BadRequestObjectResult($"Bad confirmation code for email: {email}");

            return new OkObjectResult($"User {email} confirmed");
        }

        [AllowAnonymous]
        [HttpGet("~/Account/ResetPassword", Name = "ResetPassword")]
        public async Task<IActionResult> ResetPassword(string email, string code)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return new BadRequestObjectResult($"Invalid email: {email}");

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (!result.Succeeded)
                return new BadRequestObjectResult($"Bad confirmation code for email: {email}");

            return new OkObjectResult($"User {email} confirmed");
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        #endregion
    }
}
