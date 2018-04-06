using System;
using System.ComponentModel.DataAnnotations;

namespace dotnet_shoppingCart.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        [Required]
        public String CategoryName { get; set; }

    }
}