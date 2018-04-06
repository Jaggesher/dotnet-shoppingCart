using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace dotnet_shoppingCart.ViewModels
{
    public class ProductViewModel
    {

        [Required]
        public IFormFile Img { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "The {0} Must be at least {2} and at most {1} characters long.", MinimumLength = 3)]
        [Display(Name = "Description")]
        public String Description { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Display(Name = "In Stock")]
        public uint InStock { get; set; }

        [Required]
        [Range(0, 100000000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Display(Name = "Price")]
        public uint Price { get; set; }
    }
}