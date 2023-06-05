using FarmMarket.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmMarket.Data.Interfaces
{
    public interface IFarmProductService
    {
        IEnumerable<FarmProduct> GetFarmProducts();
        Task<FarmProduct> GetFarmProduct(Guid productId);
        Task<FarmProduct> AddFarmProduct(FarmProduct product);
        Task<bool> UpdateFarmProduct(FarmProduct product, Guid productId);
        void DeleteFarmProduct(Guid productId);
    }
}
