using AutoMapper;
using BehShop.Application.CatalogServices.CatalogType;
using BehShop.Domain.Catalogs;

namespace BehShop.Infrastructure.MappingProfile
{
    public class CatalogMappingProfile : Profile
    {
        public CatalogMappingProfile()
        {
            CreateMap<CatalogType,CatalogTypeDTO>().ReverseMap();
        }
    }
}
