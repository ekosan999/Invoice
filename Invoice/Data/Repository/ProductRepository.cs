using AutoMapper;
using Invoice.Dtos.Products;
using Invoice.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Data.Repository
{
    public interface IProductRepository
    {
        Task AddAsync(Products products);
        Task<List<ProductViewDto>> GetAll();
        Task<ProductViewDto> GetById(int id);
        Task Update(ProductUpdateDto updateDto);
        Task UpdateQuantity(int productId,int quantity);
        void DeleteById(int id);
        Task SaveChangeAsync();

    }
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddAsync(Products products)
        {
            await _context.Products.AddAsync(products);
        }

        public async Task Update(ProductUpdateDto updateDto)
        {
            var model = await _context.Products.AddAsync(_mapper.Map<Products>(updateDto));
            _context.Update(model);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductViewDto>> GetAll()
        {
            var productsList = await _context.Products.Include(x => x.Category).ToListAsync();
            return _mapper.Map<List<ProductViewDto>>(productsList);
        }

        public  async Task<ProductViewDto> GetById(int id)
        {
            var model = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            return  _mapper.Map<ProductViewDto>(model);

        }

        public async void DeleteById(int id)
        {
            var model = await _context.Products.FindAsync(id);
            model.DeleteOn = DateTimeOffset.Now;
            _context.Update(model);
        }

        public async Task UpdateQuantity(int productId, int quantity)
        {
            var model = await  _context.Products.FindAsync(productId);
            model.Quantity = model.Quantity - quantity;
            _context.Update(model);
            
        }
    }
}
