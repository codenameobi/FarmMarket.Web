using FarmMarket.Data.Model;

namespace FarmMarket.API.Request
{
    public record FarmProductRequest(
        string Name,
        string Description,
        int Unit,
        int Amount
    )
    {
        public FarmProduct ToFarmProduct( FarmProductRequest product )
        {
            return new FarmProduct
            {
                Name = product.Name,
                Description = product.Description,
                Unit = product.Unit,
                Amount = product.Amount,
            };
        }
    }
}
