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
        FarmProduct GetFarmProduct(Guid productId);
        IEnumerable<FarmProduct> GetFarmProducts(string productName);
        Task<Guid> AddFarmProduct(FarmProduct product);
        bool UpdateFarmProduct(FarmProduct farmProduct);
        void DeleteFarmProduct(Guid productId);
    }
}
