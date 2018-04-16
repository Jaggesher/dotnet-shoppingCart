using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnet_shoppingCart.ViewModels
{
    public class IDsViewModel
    {
        [Required]
        public List<Guid> Ids { get; set; }
    }
}