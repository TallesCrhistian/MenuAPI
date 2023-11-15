using AutoMapper;
using MenuAPI.Business.Interfaces;
using MenuAPI.Data.Repository.Interfaces;
using MenuAPI.Entites;
using MenuAPI.Shared.DTOs;

namespace MenuAPI.Business
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository _iBaseRepository;

        public ProductBusiness(IMapper mapper, IBaseRepository iBaseRepository)
        {
            _mapper = mapper;
            _iBaseRepository = iBaseRepository;
        }

        public async Task<ProductDTO> Create(ProductDTO productDTO)
        {
            productDTO.CreatedAt = DateTime.Now.ToUniversalTime();

            Product product = _mapper.Map<Product>(productDTO);

            product = await _iBaseRepository.Create(product);

            productDTO = (product is not null) ? _mapper.Map<ProductDTO>(product)
                : throw new HttpRequestException();

            return productDTO;
        }

        public async Task<ProductDTO> Read(Guid id)
        {
            Product product = await _iBaseRepository.Read<Product>(id);

            ProductDTO productDTO = product is not null ? _mapper.Map<ProductDTO>(product)
                : throw new HttpRequestException();

            return productDTO;
        }

        public async Task<ProductDTO> Update(ProductDTO productDTO, Guid id)
        {

            Product product = await _iBaseRepository.Read<Product>(id);

            if (product is not null)
            {
                product = _mapper.Map<Product>(productDTO);

                product.UpdatedAt = DateTime.Now.ToUniversalTime();
                product.Id = id;

                product = await _iBaseRepository.Update(product);

                productDTO = product is not null ? _mapper.Map<ProductDTO>(product)
                    : throw new HttpRequestException();

                return productDTO;
            }
            else
            {
                throw new HttpRequestException();
            }
        }

        public async Task<ProductDTO> Delete(Guid id)
        {
            Product product = await _iBaseRepository.Read<Product>(id);

            if (product is not null)
            {
                await _iBaseRepository.Delete<Product>(id);
            }
            else
            {
                throw new HttpRequestException();
            }

            ProductDTO productDTO = _mapper.Map<ProductDTO>(product);

            return productDTO;
        }
    }
}
