using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_shoppingCart.Helpers;
using dotnet_shoppingCart.Services;
using dotnet_shoppingCart.Models;
using dotnet_shoppingCart.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace dotnet_shoppingCart.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtFactoryService _jwtFactory;
        public AuthController(UserManager<ApplicationUser> userManager, IJwtFactoryService jwtFactory)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Post([FromBody] RegistrationViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded) return BadRequest(Errors.AddErrorsToModelState(result, ModelState));

            return new ObjectResult("Account created");

        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]loginViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null && (await _userManager.CheckPasswordAsync(user, model.Password)))
            {

                var response = new
                {
                    id = user.Id,
                    auth_token = await _jwtFactory.GenerateToken(user.UserName, user.Id)
                };

                var jwt = JsonConvert.SerializeObject(response);
                return new OkObjectResult(jwt);

            }

            return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(_userManager);
        }


    }
}