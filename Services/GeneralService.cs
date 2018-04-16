using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_shoppingCart.Models;
using Microsoft.EntityFrameworkCore;
using dotnet_shoppingCart.Data;
using dotnet_shoppingCart.ViewModels;
using System.Linq;

namespace dotnet_shoppingCart.Services
{
    public class GeneralService : IGeneralService
    {
        private readonly ApplicationDbContext _dbContex;
        public GeneralService(ApplicationDbContext dbContext)
        {
            _dbContex = dbContext;
        }

        public Task<bool> AddShipment(ShipmentViewModel newShipment)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> AllProducts()
        {
            return await _dbContex.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> AllProductsByIds(IDsViewModel IDs)
        {
            return await _dbContex.Products.Where(X => IDs.Ids.Contains(X.Id)).Include(Y => Y.Category).ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<Product> SingleProduct(Guid Id)
        {
            return await _dbContex.Products.Where(X => X.Id == Id).Include(X => X.Category).FirstAsync();
        }
    }
}