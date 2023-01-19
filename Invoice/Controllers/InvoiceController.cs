using AutoMapper;
using Invoice.Data.Repository;
using Invoice.Dtos.Billing;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : Controller
    {
        private readonly InvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        private readonly ProductRepository _productRepository;

        public InvoiceController(InvoiceRepository invoiceRepository,
            IMapper mapper, ProductRepository productRepository)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateInvoice(InvoiceCreateDto createDto)
        {
            var result = new InvoiceViewDto();
            foreach (var item in createDto.InvoiceDetails)
            {
                var product = await _productRepository.GetById(item.ProductsId);
                if (product == null) return NotFound("Product Not Found");
                if (product.MaxDiscount < item.Discount) return BadRequest($"Error!! Maxdiscount Is {product.MaxDiscount}");
            }
                var model = _mapper.Map<Invoices>(createDto);
                await _invoiceRepository.AddAsync(model);
                await _invoiceRepository.SaveChangeAsync();
                result = await _invoiceRepository.GetById(model.Id);

            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _invoiceRepository.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _invoiceRepository.GetById(id);
            if (result == null) return NotFound("Invoice Not Found");
            return Ok(result);
        }
    }
}






/*
var model = new Invoices
{
    Description = createDto.Description,
    CreateBy = DateTimeOffset.Now.ToString(),
    InvoiceDetails = new List<InvoiceDetail>
                    {
                        new InvoiceDetail
                        {
                            CreateOn = DateTimeOffset.Now,
                            ProductsId = createDto.InvoiceDetails.FirstOrDefault().ProductsId,
                            Quantity = quantity,
                            UnitPrice = product.Price,
                            TotalPrice = product.Price * quantity - discount,
                            Discount = createDto.InvoiceDetails.FirstOrDefault().Discount
                        }
                    }
};*/