using System;
using System.Collections.Generic;
using dotnet_shoppingCart.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dotnet_shoppingCart.Services;
using dotnet_shoppingCart.Helpers;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace dotnet_shoppingCart.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }


        [HttpPost("AddProduct")]
        public async Task<IActionResult> PostAsync([FromForm] ProductViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            ///File Upload Check
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var extension = Path.GetExtension(model.Img.FileName);

            if (!allowedExtensions.Contains(extension.ToLower()) || (model.Img.Length > 2000000)) return BadRequest(Errors.AddErrorToModelState("img", "Select jpg or jpeg or png less than 2Μ.", ModelState));

            Guid id = new Guid();
            var fileName = Path.Combine("Products", id + extension);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);

            try
            {

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.Img.CopyToAsync(stream);
                }

            }
            catch
            {
                return BadRequest(Errors.AddErrorToModelState("Message", "Somethins Went Wrong", ModelState));
            }

            if (await _adminService.AddProduct(model, fileName, id))
                return new OkObjectResult(new { Message = "Success" });

            return BadRequest(Errors.AddErrorToModelState("Message", "Somethins Went Wrong", ModelState));
        }



        [HttpPost("AddCategory")]
        public async Task<IActionResult> Post([FromBody] CategoryViewmodel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _adminService.AddCategory(model))
                return new OkObjectResult(new { Message = "Success" });

            return BadRequest(Errors.AddErrorToModelState("Message", "Somethins Went Wrong", ModelState));

        }

        [HttpGet("AllCategory")]

        public async Task<IActionResult> Get()
        {
            var result = await _adminService.AllCategory();
            return new OkObjectResult(result);
        }

        [HttpGet("AllShipments")]

        public async Task<IActionResult> GetShipments()
        {
            var result = await _adminService.AllShipments();
            return new OkObjectResult(result);
        }


    }
}