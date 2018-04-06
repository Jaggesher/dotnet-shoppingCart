using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_shoppingCart.Models;
using dotnet_shoppingCart.ViewModels;
using dotnet_shoppingCart.Data;
using Microsoft.EntityFrameworkCore;

namespace dotnet_shoppingCart.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _dbContex;
        public AdminService(ApplicationDbContext context)
        {
            _dbContex = context;
        }

        public async Task<bool> AddCategory(CategoryViewmodel newCategory)
        {
            var entity = new Category
            {
                Id = new Guid(),
                ProductCategory = newCategory.ProductCategory
            };
            
            _dbContex.Categories.Add(entity);
            return 1 == await _dbContex.SaveChangesAsync();

        }

        public Task<bool> AddProduct(ProductViewModel newProduct)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> AllCategory()
        {
            return await _dbContex.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Shipment>> AllShipments()
        {
            return await _dbContex.Shipments.Include(b => b.OrderedProduct).ToListAsync();
        }
    }
}