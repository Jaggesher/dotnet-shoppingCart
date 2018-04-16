using System;
using System.ComponentModel.DataAnnotations;

namespace dotnet_shoppingCart.ViewModels
{
    public class OrderProductViewModel
    {
        [Required]
        public Guid ProductID { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}