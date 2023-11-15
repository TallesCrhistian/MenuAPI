using AutoMapper;
using MenuAPI.Entites;
using MenuAPI.Shared.DTOs;
using MenuAPI.Shared.ViewModels.Adress;
using MenuAPI.Shared.ViewModels.Enterprise;
using MenuAPI.Shared.ViewModels.Product;

namespace MenuAPI.Utils.MappingProfiles
{
    public class MappingProfile : Profile
    {
       public MappingProfile() 
        {
            CreateMap<Enterprise, EnterpriseDTO>()
               .ForMember(dest => dest.AdressDTO, opt => opt.MapFrom(src => src.Adress));

            CreateMap<EnterpriseDTO, Enterprise>()
               .ForMember(dest => dest.Adress, opt => opt.MapFrom(src => src.AdressDTO));

            CreateMap<EnterpriseCreateViewModel, EnterpriseDTO>();
            CreateMap<EnterpriseUpdateViewModel, EnterpriseDTO>();
            CreateMap<EnterpriseListViewModel, EnterpriseDTO>();

            CreateMap<EnterpriseDTO, EnterpriseViewModel>()
               .ForMember(dest => dest.AdressViewModel, opt => opt.MapFrom(src => src.AdressDTO));


            CreateMap<Adress, AdressDTO>()
               .ReverseMap();  
            
            CreateMap<AdressCreateViewModel, AdressDTO>();
            CreateMap<AdressUpdateViewModel, AdressDTO>();
            CreateMap<AdressListViewModel, AdressDTO>();
            CreateMap<AdressDTO, AdressViewModel>();


            CreateMap<Product, ProductDTO>()
              .ForMember(dest => dest.EnterpriseDTO, opt => opt.MapFrom(src => src.Enterprise));

            CreateMap<ProductDTO, Product>()
               .ForMember(dest => dest.Enterprise, opt => opt.MapFrom(src => src.EnterpriseDTO));

            CreateMap<ProductCreateViewModel, ProductDTO>();
            CreateMap<ProductUpdateViewModel, ProductDTO>();
            CreateMap<ProductListViewModel, ProductDTO>();

            CreateMap<ProductDTO, ProductViewModel>()
               .ForMember(dest => dest.EnterpriseViewModel, opt => opt.MapFrom(src => src.EnterpriseDTO));
        }
    }
}
