using AutoMapper;
using DataLayer;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get([FromQuery] int[]? categoryId, [FromQuery] string? dir = "asc", [FromQuery] int? fromPrice = null, [FromQuery] int? toPrice = null, [FromQuery] string? name = null)
        {

            IEnumerable<Product> products = await _productService.Get(categoryId, dir, fromPrice, toPrice, name);
            IEnumerable<ProductDTO> productsDTO = _mapper.Map<IEnumerable<Product>, IEnumerable< ProductDTO > >(products);
            return Ok(productsDTO);
        }
    }
}
