using FarmMarket.API.Request;
using FarmMarket.API.Response;
using FarmMarket.Data;
using FarmMarket.Data.Interfaces;
using FarmMarket.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FarmMarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmProductController : ControllerBase
    {
        private readonly IFarmProductService _farmProductService;
        private readonly ApplicationDbContext _context;

        public FarmProductController(IFarmProductService farmProductService, ApplicationDbContext context) 
        {
            _farmProductService = farmProductService;
            _context = context;
        }
        // GET: api/<FarmProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FarmProduct>>> GetAllFarmProduct()
        {
            return await _context.FarmProducts.OrderBy(p => p.Id).ToListAsync();
        }

        // GET api/<FarmProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FarmProduct>> Get(Guid id)
        {
            return await _farmProductService.GetFarmProduct(id);
        }

        // POST api/<FarmProductController>
        [HttpPost]
        public ActionResult<FarmProduct> Post([FromBody] FarmProductRequest productRequest)
        {
            var product = productRequest.ToFarmProduct(productRequest);
            _farmProductService.AddFarmProduct(product);
            return product;
        }

        // PUT api/<FarmProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Put(Guid id, [FromBody] FarmProductRequest productRequest)
        {
            var product = productRequest.ToFarmProduct(productRequest);
            return await _farmProductService.UpdateFarmProduct(product, id);
        }

        // DELETE api/<FarmProductController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _farmProductService.DeleteFarmProduct(id);
        }
    }
}
