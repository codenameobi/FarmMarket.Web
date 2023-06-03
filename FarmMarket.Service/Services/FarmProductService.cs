using FarmMarket.Data;
using FarmMarket.Data.Interfaces;
using FarmMarket.Data.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmMarket.Service.Services
{
    public class FarmProductService : IFarmProductService
    {
        private readonly ApplicationDbContext _context;
        public FarmProductService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<FarmProduct> AddFarmProduct(FarmProduct product)
        {
            var farmProduct = _context.FarmProducts.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public void DeleteFarmProduct(Guid productId)
        {
            var farmProduct = _context.FarmProducts.Where(p => p.Id == productId).FirstOrDefault();
            if (farmProduct != null)
            {
                _context.FarmProducts.Remove(farmProduct);
                _context.SaveChanges();
            }
        }

        public FarmProduct GetFarmProduct(Guid productId)
        {
            var farmProduct = _context.FarmProducts.Where(p => p.Id == productId).FirstOrDefault();
            return farmProduct;
        }

        public IEnumerable<FarmProduct> GetFarmProducts()
        {
            var farmProducts = _context.FarmProducts.OrderBy(p => p.Id).ToList();
            return farmProducts;
        }

        public bool UpdateFarmProduct(FarmProduct product, Guid productId)
        {
            var farmProduct = _context.FarmProducts.Where(p => p.Id == productId).FirstOrDefault();
            _context.FarmProducts.Update(farmProduct);
            return true;

        }

        public IEnumerable<FarmProduct> GetFarmProducts(string productName)
        {
            throw new NotImplementedException();
        }
    }
}
