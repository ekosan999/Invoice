using AutoMapper;
using Invoice.Dtos.Products;
using Invoice.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Data.Repository
{
    public interface ICategoryRepository
    {
        Task AddAsync(Categories categories);
        Task<List<CategoryViewDto>> GetAll();
        Task<CategoryViewDto> GetById(int id);
        Task Update(CategoryUpdateDto updateDto);
        void DeleteById(int id);
        Task SaveChangeAsync();

    }
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CategoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddAsync(Categories categories)
        {
            await _context.Categories.AddAsync(categories);
        }

        public async void DeleteById(int id)
        {
            var model = await _context.Categories.FindAsync(id);
            model.DeleteOn = DateTimeOffset.Now;
            _context.Update(model);
        }
        public async Task<CategoryViewDto> GetById(int id)
        {
            var model = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<CategoryViewDto>(model);
        }



        public async Task Update(CategoryUpdateDto category)
        {
            var model = await _context.Categories.AddAsync(_mapper.Map<Categories>(category));
            _context.Update(model);
            
        }

        public async Task<List<CategoryViewDto>> GetAll()
        {
            var categoryList = await _context.Categories.ToListAsync();
            return _mapper.Map<List<CategoryViewDto>>(categoryList);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

      
    }
}
