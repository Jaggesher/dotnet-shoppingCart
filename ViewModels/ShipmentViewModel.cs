using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnet_shoppingCart.ViewModels
{
    public class ShipmentViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} Must be at least {2} and at most {1} characters long.", MinimumLength = 3)]
        [Display(Name = "Name")]
        public String Name { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "The {0} Must be at least {2} and at most {1} characters long.", MinimumLength = 3)]
        [Display(Name = "Address")]
        public String Address { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} Must be at least {2} and at most {1} characters long.", MinimumLength = 3)]
        [Display(Name = "Phone")]
        public String Phone { get; set; }

        [Required]
        public uint TotalCost { get; set; }

        [Required]
        public List<OrderProductViewModel> OrderProduct { get; set; }
        

    }
}