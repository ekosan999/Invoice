using AutoMapper;
using Invoice.Dtos.Billing;
using Invoice.Dtos.InvoiceDetails;
using Invoice.Dtos.Products;
using Invoice.Models;

namespace Invoice.Mapping
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<ProductCreateDto, Products>()
                .ForMember(dest => dest.CreateOn, opt => opt.MapFrom(x => DateTimeOffset.Now));
                
            CreateMap<ProductUpdateDto, Products>();
            CreateMap<Products, ProductViewDto>();

            CreateMap<CategoryCreateDto, Categories>();
            CreateMap<CategoryUpdateDto, Categories>();
            CreateMap<Categories, CategoryViewDto>();


            CreateMap<InvoiceCreateDto, Invoices>()
                .ForMember(dest => dest.CreateOn,opt => opt.MapFrom(src => DateTimeOffset.Now));
            CreateMap<InvoiceUpdateDto, Invoices>();
            CreateMap<Invoices, InvoiceViewDto>();


            CreateMap<InvoiceDetail, InvoiceDetailsViewDto>();
            CreateMap<InvoiceDetailCreateDto, InvoiceDetail>();
            CreateMap<InvoiceDetailsUpdateDto, InvoiceDetail>();

        }
    }
}
