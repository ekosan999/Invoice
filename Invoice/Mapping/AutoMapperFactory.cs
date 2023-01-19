using AutoMapper;

namespace Invoice.Mapping
{
    public class AutoMapperFactory
    {
        public static IMapper CreateMapper()
        {
            return new MapperConfiguration(cgf =>
            {
                cgf.AddProfile<AutoMapper>();
            }
            ).CreateMapper();
        }
    }
}
