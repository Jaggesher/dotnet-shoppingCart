using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnet_shoppingCart.Models
{
    public class Shipment
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public String Name { get; set; }

        [Required]
        [StringLength(1000)]
        public String Address { get; set; }

        [Required]
        [StringLength(30)]
        public String Phone { get; set; }

        public int TotalCost { get; set; }

        [Required]
        public bool IsDelivered { get; set; }

        public List<OrderedProduct> OrderedProduct { get; set; }
    }
}