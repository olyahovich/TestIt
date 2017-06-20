﻿using System.Threading.Tasks;
using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using TestIT.Data;
using TestIT.Entities;
using TestIT.Web.ViewModels;

namespace TestIT.Web.Api
{
    [SwaggerIgnore]
    [Route("api")]
    [RequireHttps]
    public class ResourceController : Controller
    {
        private readonly UserManager<User> _userManager;

        public ResourceController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
        [HttpGet("message")]
        public async Task<IActionResult> GetMessage()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return BadRequest();
            }

            return Content($"{user.UserName} has been successfully authenticated.");
        }
    }
}