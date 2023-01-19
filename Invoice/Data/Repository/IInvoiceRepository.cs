using AutoMapper;
using Invoice.Dtos.Billing;
using Invoice.Dtos.InvoiceDetails;
using Invoice.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Data.Repository
{
    public interface IInvoiceRepository
    {
        Task AddAsync(Invoices invoice);
        Task<List<InvoiceViewDto>> GetAll();
        Task<InvoiceViewDto> GetById(int id);
        //Task Update(InvoiceUpdateDto updateDto);
        void DeleteById(int id);
        Task SaveChangeAsync();
    }
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ProductRepository _productRepository;
        protected IQueryable<Invoices> FinalQuery => _context.Invoices;
        public InvoiceRepository(ApplicationDbContext context,
            IMapper mapper, ProductRepository productRepository)
        {
            _context = context;
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task AddAsync(Invoices invoice)
        {
            await _context.Invoices.AddAsync(invoice);
            foreach (var invoicedetail in invoice.InvoiceDetails)
            {
                var product = await _productRepository.GetById(invoicedetail.ProductsId);
                var dicount = (product.Price * invoicedetail.Quantity / 100) * invoicedetail.Discount;
                var totalPrice = product.Price * invoicedetail.Quantity;
                invoicedetail.UnitPrice = product.Price;
                invoicedetail.TotalPrice = totalPrice - dicount;
                invoicedetail.CreateOn = DateTimeOffset.Now;
                await _productRepository.UpdateQuantity(invoicedetail.ProductsId, invoicedetail.Quantity);
                invoice.TotalAmount = invoice.TotalAmount + invoicedetail.TotalPrice;
            }
        }
        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<InvoiceViewDto>> GetAll()
        {
            var invoices = await FinalQuery.Include(x => x.InvoiceDetails).ToListAsync();
            return _mapper.Map<List<InvoiceViewDto>>(invoices);
        }

        public async Task<InvoiceViewDto> GetById(int id)
        {
            var model = await FinalQuery.Where(x => x.Id == id).Include(x => x.InvoiceDetails).FirstOrDefaultAsync();
            return _mapper.Map<InvoiceViewDto>(model);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
