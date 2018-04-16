using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_shoppingCart.ViewModels;
using dotnet_shoppingCart.Models;

namespace dotnet_shoppingCart.Services
{
    public interface IGeneralService
    {
        Task<bool> AddShipment(ShipmentViewModel newShipment);
        Task<IEnumerable<Product>> AllProducts();
        Task<IEnumerable<Product>> AllProductsByIds(IDsViewModel IDs);
        Task<Product> SingleProduct(Guid Id);
    }
}