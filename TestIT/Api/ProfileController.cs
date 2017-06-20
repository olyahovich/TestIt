using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestIT.Web.ViewModels.ManageViewModels;
using TestIT.Data;
using TestIT.Entities;
using TestIT.Web.Api;
using TestIT.Web.ViewModels.Default;

namespace TestIt.Web.Api
{
    [SwaggerIgnore]
    [Authorize]
    [RequireHttps]
    [Route("api/[controller]")]
    public class ProfileController : BaseController
    {
        private readonly UserManager<User> _userManager;

        public ProfileController(
            TestItContext context,
            SignInManager<User> signInManager,
            UserManager<User> userManager) : base(
            context,
            signInManager,
            userManager)
        {
        }

        [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
        [HttpPost("~/profile/changePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel passwordUpdate)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var passwordChanged = await _userManager.ChangePasswordAsync(user, passwordUpdate.OldPassword,
                    passwordUpdate.NewPassword);

                if (passwordChanged.Succeeded)
                {
                    return Json(Ok("password successfully changed."));
                }

                return Json(BadRequest("Password not changed, user not found"));
            }

            return Json(NotFound("Password not changed, user not found"));
        }



        /// <summary>
        /// GET: api/profile
        /// </summary>
        /// <returns>A Json-serialized object representing the currentaccount.</returns>
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var id = await GetCurrentUserId();
            var user = DbContext.Users.Where(i => i.Id == id).FirstOrDefault();
            if (user != null)
                return
                    new JsonResult(
                        new UserViewModel() {UserName = user.UserName, Email = user.Email, DisplayName = user.FullName},
                        DefaultJsonSettings);
            else
                return NotFound(new
                {
                    error = String.Format("User ID {0} has notbeen found", id)
                });
        }

        /// <summary>/// GET: api/accounts/{id}/// ROUTING TYPE: attribute-based/// </summary>/// <returns>A Json-serialized object representing a singleaccount.</returns>[httpget("{id}")]public IActionResult Get(string id)

        /// <summary>
        /// PUT: api/accounts/{id}
        /// </summary>
        /// <returns>Updates current User and return it accordingly.</returns>
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] UserViewModel uvm)
        {
            if (uvm != null)
            {
                try
                {
                    // retrieve user
                    var id = await GetCurrentUserId();
                    User user = await UserManager.FindByIdAsync(id);
                    if (user == null) throw new Exception("User not found");

                    // check for current password
                    if (await UserManager.CheckPasswordAsync(user, uvm.Password))
                    {
                        // current password ok, perform changes (if any)
                        bool hadChanges = false;

                        if (user.Email != uvm.Email)
                        {
                            // check if the Email already exists
                            User user2 = await UserManager.FindByEmailAsync(uvm.Email);
                            if (user2 != null && user.Id != user2.Id) throw new Exception("E-Mail already exists.");
                            else await UserManager.SetEmailAsync(user, uvm.Email);
                            hadChanges = true;
                        }

                        if (!string.IsNullOrEmpty(uvm.PasswordNew))
                        {
                            await UserManager.ChangePasswordAsync(user, uvm.Password, uvm.PasswordNew);
                            hadChanges = true;
                        }

                        if (user.FullName != uvm.DisplayName)
                        {
                            user.FullName = uvm.DisplayName;
                            hadChanges = true;
                        }

                        if (hadChanges)
                        {
                            // if we had at least 1 change:
                            // update LastModifiedDate
                            user.ModifiedOn = DateTime.Now;
                            // persist the changes into the Database.
                            DbContext.SaveChanges();
                        }

                        // return the updated User to the client.
                        return new JsonResult(new UserViewModel()
                        {
                            UserName = user.UserName,
                            Email = user.Email,
                            DisplayName = user.FullName
                        }, DefaultJsonSettings);
                    }
                    else throw new Exception("Old password mismatch");
                }
                catch (Exception e)
                {
                    // return the error.
                    return new JsonResult(new {error = e.Message});
                }
            }

            // return a HTTP Status 404 (Not Found) if we couldn't find a suitable item.
            return NotFound(new {error = String.Format("Current User has not been found")});


        }
    }
}
