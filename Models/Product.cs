using System;
using System.ComponentModel.DataAnnotations;
namespace dotnet_shoppingCart.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required]
        public String Img { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        public String Description { get; set; }
    }
}