using System;
using System.ComponentModel.DataAnnotations;

namespace dotnet_shoppingCart.Models
{
    public class OrderedProduct
    {
        public Guid Id { get; set; }

        [Required]
        public Guid ProductID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public Guid ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
        
    }
}