using AutoMapper;
using Invoice.Data.Repository;
using Invoice.Dtos.Products;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductsController(ProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductViewDto>>> GetAll()
        {
            var product = await _productRepository.GetAll();
            return product;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<ProductViewDto>> CreateCategory(ProductCreateDto productCreateDto)
        {
            try
            {
                var model = _mapper.Map<Products>(productCreateDto);
                await _productRepository.AddAsync(model);
                await _productRepository.SaveChangeAsync();
                var respons = await _productRepository.GetById(model.Id);
                return Ok(respons);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            _productRepository.DeleteById(id);
            return Ok();

        }
    }
}
