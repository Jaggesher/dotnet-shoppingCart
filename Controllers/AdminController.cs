using System;
using System.Collections.Generic;
using dotnet_shoppingCart.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dotnet_shoppingCart.Services;
using dotnet_shoppingCart.Helpers;

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

        [HttpPost("AddCategory")]

        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPost("AddProduct")]
        public IActionResult Post([FromForm] ProductViewModel model)
        {
            //if (model.ProductImage == null || model.ProductImage.Length == 0) return BadRequest("No File Received"); 
            return Json(model);
            //return Ok(model.ProductImage.Name);
        }

        [HttpGet]

        public IActionResult Get()
        {
            return Ok("Things Works");
        }
    }
}