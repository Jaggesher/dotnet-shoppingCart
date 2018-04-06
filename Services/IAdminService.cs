using System;
using System.Threading.Tasks;
using dotnet_shoppingCart.ViewModels;
using dotnet_shoppingCart.Models;
using System.Collections.Generic;

namespace dotnet_shoppingCart.Services
{
    public interface IAdminService
    {
        Task<bool> AddCategory(CategoryViewmodel newCategory);
        Task<IEnumerable<Category>> AllCategory();
        Task<bool> AddProduct(ProductViewModel newProduct);
        Task<IEnumerable<Shipment>> AllShipments();
        
    }
}