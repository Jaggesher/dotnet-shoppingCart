using System;
using System.ComponentModel.DataAnnotations;

namespace dotnet_shoppingCart.ViewModels
{
    public class CategoryViewmodel
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} Must be at least {2} and at most {1} characters long.", MinimumLength = 3)]
        [Display(Name = "Product Category")]
        public String ProductCategory { get; set; }
    }
}