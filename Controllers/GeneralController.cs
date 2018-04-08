using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_shoppingCart.Services;

namespace dotnet_shoppingCart.Controllers
{
    [Route("api/[controller]")]
    public class GeneralController : Controller
    {
        private readonly IGeneralService _generalService;
        public GeneralController(IGeneralService generalService)
        {
            _generalService = generalService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Things Works");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var result = await _generalService.SingleProduct(id);
            return new OkObjectResult(result);
        }

        [HttpGet("AllProducts")]
        public async Task<IActionResult> AllProducts()
        {
            var result = await _generalService.AllProducts();
            return new OkObjectResult(result);
        }
    }
}