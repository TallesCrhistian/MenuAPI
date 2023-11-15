using AutoMapper;
using MenuAPI.Business.Interfaces;
using MenuAPI.Data.WorkUnit.Interfaces;
using MenuAPI.Services.Interfaces;
using MenuAPI.Shared.DTOs;
using MenuAPI.Shared.Messages;
using MenuAPI.Shared.ViewModels.Adress;
using System.Net;

namespace MenuAPI.Services
{
    public class AdressServices : IAdressServices
    {
        private readonly IWorkUnit _iWorkUnit;
        private readonly IMapper _mapper;
        private readonly IAdressBusiness _iAdressBusiness;

        public AdressServices(IWorkUnit workUnit, IMapper mapper, IAdressBusiness iAdressBusiness)
        {
            _iWorkUnit = workUnit;
            _mapper = mapper;
            _iAdressBusiness = iAdressBusiness;
        }

        public async Task<ServiceResponseDTO<AdressViewModel>> Create(AdressCreateViewModel adressCreateViewModel)
        {
            ServiceResponseDTO<AdressViewModel> serviceResponseDTO = new ServiceResponseDTO<AdressViewModel>();

            try
            {
                AdressDTO adressDTO = _mapper.Map<AdressDTO>(adressCreateViewModel);
                adressDTO = await _iAdressBusiness.Create(adressDTO);

                serviceResponseDTO.GenericData = _mapper.Map<AdressViewModel>(adressDTO);
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

        public async Task<ServiceResponseDTO<AdressViewModel>> Read(Guid id)
        {
            ServiceResponseDTO<AdressViewModel> serviceResponseDTO = new ServiceResponseDTO<AdressViewModel>();

            try
            {
                AdressDTO adressDTO = await _iAdressBusiness.Read(id);

                serviceResponseDTO.GenericData = _mapper.Map<AdressViewModel>(adressDTO);
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

        public async Task<ServiceResponseDTO<AdressViewModel>> Update(AdressUpdateViewModel adressUpdateViewModel, Guid id)
        {
            ServiceResponseDTO<AdressViewModel> serviceResponseDTO = new ServiceResponseDTO<AdressViewModel>();

            try
            {
                AdressDTO adressDTO = _mapper.Map<AdressDTO>(adressUpdateViewModel);
                adressDTO = await _iAdressBusiness.Update(adressDTO, id);

                serviceResponseDTO.GenericData = _mapper.Map<AdressViewModel>(adressDTO);
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

        public async Task<ServiceResponseDTO<AdressViewModel>> Delete(Guid id)
        {
            ServiceResponseDTO<AdressViewModel> serviceResponseDTO = new ServiceResponseDTO<AdressViewModel>();

            try
            {
                AdressDTO adressDTO = await _iAdressBusiness.Delete(id);

                serviceResponseDTO.GenericData = _mapper.Map<AdressViewModel>(adressDTO);
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
