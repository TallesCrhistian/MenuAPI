using AutoMapper;
using MenuAPI.Business.Interfaces;
using MenuAPI.Data.Repository.Interfaces;
using MenuAPI.Entites;
using MenuAPI.Shared.DTOs;
using MenuAPI.Shared.Exceptions;
using MenuAPI.Shared.Messages;
using System.Net;

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
                : throw new CustomException(HttpStatusCode.BadRequest, BadRequestMessages.ProductNoCreated, new HttpRequestException());

            return productDTO;
        }

        public async Task<ProductDTO> Read(Guid id)
        {
            Product product = await _iBaseRepository.Read<Product>(id);

            ProductDTO productDTO = product is not null ? _mapper.Map<ProductDTO>(product)
                : throw new CustomException(HttpStatusCode.NotFound, NotFoundMessages.Product, new HttpRequestException());

            return productDTO;
        }

        public async Task<ProductDTO> Update(ProductDTO productDTO, Guid id)
        {

            Product product = await _iBaseRepository.Read<Product>(id);

            if (product is not null)
            {product = _mapper.Map<Product>(productDTO);

                product.UpdatedAt = DateTime.Now.ToUniversalTime();
                product.Id = id;

                product = await _iBaseRepository.Update(product);

                productDTO = product is not null ? _mapper.Map<ProductDTO>(product)
                    : throw new CustomException(HttpStatusCode.BadRequest, BadRequestMessages.ProductNoUpdate, new HttpRequestException());

                return productDTO;
            }
            else
            {
                throw new CustomException(HttpStatusCode.NotFound, NotFoundMessages.Product, new HttpRequestException());
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
                throw new CustomException(HttpStatusCode.NotFound, NotFoundMessages.Product, new HttpRequestException());
            }

            ProductDTO productDTO = _mapper.Map<ProductDTO>(product);

            return productDTO;
        }
    }
}
