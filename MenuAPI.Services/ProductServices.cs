using AutoMapper;
using MenuAPI.Business;
using MenuAPI.Business.Interfaces;
using MenuAPI.Data.WorkUnit.Interfaces;
using MenuAPI.Services.Interfaces;
using MenuAPI.Shared.DTOs;
using MenuAPI.Shared.Messages;
using MenuAPI.Shared.ViewModels.Adress;
using MenuAPI.Shared.ViewModels.Product;
using System.Net;

namespace MenuAPI.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IWorkUnit _iWorkUnit;
        private readonly IMapper _mapper;
        private readonly IProductBusiness _iProductBusiness;

        public ProductServices(IWorkUnit workUnit, IMapper mapper, IProductBusiness iProductBusiness)
        {
            _iWorkUnit = workUnit;
            _mapper = mapper;
            _iProductBusiness = iProductBusiness;
        }

        public async Task<ServiceResponseDTO<ProductViewModel>> Create(ProductCreateViewModel productCreateViewModel)
        {
            ServiceResponseDTO<ProductViewModel> serviceResponseDTO = new ServiceResponseDTO<ProductViewModel>();

            try
            {
                ProductDTO productDTO = _mapper.Map<ProductDTO>(productCreateViewModel);
                productDTO = await _iProductBusiness.Create(productDTO);

                serviceResponseDTO.GenericData = _mapper.Map<ProductViewModel>(productDTO);
                serviceResponseDTO.StatusCode = Convert.ToInt32(HttpStatusCode.Created);
                serviceResponseDTO.Message = CreatedMessages.Adress;
                serviceResponseDTO.Sucess = true;

                await _iWorkUnit.SaveChangesAsync();
                await _iWorkUnit.CommitAsync();
            }
            catch (Exception ex)
            {
                _iWorkUnit.Rollback();

                serviceResponseDTO.Sucess = false;
                serviceResponseDTO.Message = ex.Message;
                serviceResponseDTO.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
            }

            return serviceResponseDTO;
        }

        public async Task<ServiceResponseDTO<ProductViewModel>> Read(Guid id)
        {
            ServiceResponseDTO<ProductViewModel> serviceResponseDTO = new ServiceResponseDTO<ProductViewModel>();

            try
            {
                ProductDTO productDTO = await _iProductBusiness.Read(id);

                serviceResponseDTO.GenericData = _mapper.Map<ProductViewModel>(productDTO);
                serviceResponseDTO.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                serviceResponseDTO.Message = OkMessages.OkMessage;
                serviceResponseDTO.Sucess = true;

            }
            catch (Exception ex)
            {
                _iWorkUnit.Rollback();

                serviceResponseDTO.Sucess = false;
                serviceResponseDTO.Message = ex.Message;
                serviceResponseDTO.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
            }

            return serviceResponseDTO;
        }

        public async Task<ServiceResponseDTO<ProductViewModel>> Update(ProductUpdateViewModel productUpdateViewModel, Guid id)
        {
            ServiceResponseDTO<ProductViewModel> serviceResponseDTO = new ServiceResponseDTO<ProductViewModel>();

            try
            {
                ProductDTO productDTO = _mapper.Map<ProductDTO>(productUpdateViewModel);
                productDTO = await _iProductBusiness.Update(productDTO, id);

                serviceResponseDTO.GenericData = _mapper.Map<ProductViewModel>(productDTO);
                serviceResponseDTO.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                serviceResponseDTO.Message = OkMessages.OkMessage;
                serviceResponseDTO.Sucess = true;

                await _iWorkUnit.SaveChangesAsync();
                await _iWorkUnit.CommitAsync();
            }
            catch (Exception ex)
            {
                _iWorkUnit.Rollback();

                serviceResponseDTO.Sucess = false;
                serviceResponseDTO.Message = ex.Message;
                serviceResponseDTO.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
            }

            return serviceResponseDTO;
        }

        public async Task<ServiceResponseDTO<ProductViewModel>> Delete(Guid id)
        {
            ServiceResponseDTO<ProductViewModel> serviceResponseDTO = new ServiceResponseDTO<ProductViewModel>();

            try
            {
                ProductDTO productDTO = await _iProductBusiness.Delete(id);

                serviceResponseDTO.GenericData = _mapper.Map<ProductViewModel>(productDTO);
                serviceResponseDTO.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                serviceResponseDTO.Message = OkMessages.OkMessage;
                serviceResponseDTO.Sucess = true;

                await _iWorkUnit.SaveChangesAsync();
                await _iWorkUnit.CommitAsync();
            }
            catch (Exception ex)
            {
                _iWorkUnit.Rollback();

                serviceResponseDTO.Sucess = false;
                serviceResponseDTO.Message = ex.Message;
                serviceResponseDTO.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
            }

            return serviceResponseDTO;
        }
    }
}
