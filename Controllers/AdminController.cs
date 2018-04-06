using System;
using System.Collections.Generic;
using dotnet_shoppingCart.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dotnet_shoppingCart.Services;
using dotnet_shoppingCart.Helpers;
using System.Threading.Tasks;

namespace dotnet_shoppingCart.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController( IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("AddProduct")]
        public IActionResult Post([FromForm] ProductViewModel model)
        {
            //if (model.ProductImage == null || model.ProductImage.Length == 0) return BadRequest("No File Received"); 
            return Json(model);
            //return Ok(model.ProductImage.Name);
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> Post( [FromBody] CategoryViewmodel model)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            
            var result = await _adminService.AddCategory(model);

            return new OkObjectResult(new { Message =  "Success"});

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