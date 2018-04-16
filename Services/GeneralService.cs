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

        public async Task<bool> AddShipment(ShipmentViewModel newShipment)
        {
            var entityShipment = new Shipment
            {
                Id = new Guid(),
                Name = newShipment.Name,
                Address = newShipment.Address,
                Phone = newShipment.Phone,
                IsDelivered = false,
                TotalCost = (int)newShipment.TotalCost
            };
            _dbContex.Shipments.Add(entityShipment);

            foreach (OrderProductViewModel order in newShipment.OrderProduct)
            {
                var entity = new OrderedProduct
                {
                    Id = new Guid(),
                    ProductID = order.ProductID,
                    Quantity = order.Quantity,
                    ShipmentId = entityShipment.Id
                };
                _dbContex.OrderedProducts.Add(entity);
            }
            var result = await _dbContex.SaveChangesAsync();
            var entityCount = newShipment.OrderProduct.Count + 1;
            if (result == entityCount)
            {
                try
                {
                   foreach (OrderProductViewModel order in newShipment.OrderProduct)
                    {
                        var contex = await _dbContex.Products.FindAsync(order.ProductID);
                        if (contex.InStock < order.Quantity) contex.InStock = 0;
                        else contex.InStock = (contex.InStock- order.Quantity);
                        _dbContex.SaveChanges();
                   }
                    return true;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Product>> AllProducts()
        {
            return await _dbContex.Products.Include(X => X.Category).ToListAsync();
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