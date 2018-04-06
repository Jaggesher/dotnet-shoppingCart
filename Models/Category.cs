using System;
using System.ComponentModel.DataAnnotations;

namespace dotnet_shoppingCart.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public String ProductCategory { get; set; }

    }
}