using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_shoppingCart.Helpers;
using dotnet_shoppingCart.Models;
using dotnet_shoppingCart.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_shoppingCart.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AuthController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        
        [HttpPost("Register")]
        public async Task<IActionResult> Post([FromBody] RegistrationViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
            var result = await _userManager.CreateAsync(user,model.Password);
            if(!result.Succeeded) return BadRequest(Errors.AddErrorsToModelState(result,ModelState));
            
            return new ObjectResult("Account created");

        }
    }
}