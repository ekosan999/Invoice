using AutoMapper;
using Invoice.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(CategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<CategoryViewDto>>> GetAll()
        {
            var categories = await _categoryRepository.GetAll();
            return categories;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category == null) return NotFound();
            return Ok(category);
        }
        [HttpPost]
        public async Task<ActionResult<CategoryViewDto>> CreateCategory(CategoryCreateDto categoryCreateDto)
        {
            var model = _mapper.Map<Categories>(categoryCreateDto);
            await _categoryRepository.AddAsync(model);
            await _categoryRepository.SaveChangeAsync();
            var respons = _mapper.Map<CategoryViewDto>(model);
            return Ok(respons);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            _categoryRepository.DeleteById(id);
            return Ok();

        }

    }
}
