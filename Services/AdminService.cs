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

        public async Task<bool> AddProduct(ProductViewModel newProduct, String Path)
        {
            var entity = new Product
            {
                Id = new Guid(),
                Img = Path,
                CategoryId = newProduct.CategoryId,
                Description = newProduct.Description,
                InStock = (int)newProduct.InStock,
                Price = (int)newProduct.Price
            };

            _dbContex.Products.Add(entity);
            return 1 == await _dbContex.SaveChangesAsync();

        }

        public async Task<IEnumerable<Category>> AllCategory()
        {
            return await _dbContex.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Shipment>> AllShipments()
        {
            return await _dbContex.Shipments.Include(X=>X.OrderedProduct).ToListAsync();
            //return await _dbContex.Shipments.Include(b => b.OrderedProduct).ToListAsync();
        }

        public async Task<bool> ConfirmOrder(Guid id)
        {
            var context = await _dbContex.Shipments.FindAsync(id);

            try{
                context.IsDelivered = true;
                var result = await _dbContex.SaveChangesAsync();
                return result == 1;
            }catch(Exception e){
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}