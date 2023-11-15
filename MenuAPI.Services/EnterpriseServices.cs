using AutoMapper;
using MenuAPI.Business.Interfaces;
using MenuAPI.Data.WorkUnit.Interfaces;
using MenuAPI.Services.Interfaces;
using MenuAPI.Shared.DTOs;
using MenuAPI.Shared.Exceptions;
using MenuAPI.Shared.Messages;
using MenuAPI.Shared.ViewModels.Enterprise;
using System.Net;

namespace MenuAPI.Services
{
    public class EnterpriseServices : IEnterpriseServices
    {
        private readonly IWorkUnit _iWorkUnit;
        private readonly IMapper _mapper;
        private readonly IEnterpriseBusiness _iEnterpriseBusiness;

        public EnterpriseServices(IWorkUnit workUnit, IMapper mapper, IEnterpriseBusiness iEnterpriseBusiness)
        {
            _iWorkUnit = workUnit;
            _mapper = mapper;
            _iEnterpriseBusiness = iEnterpriseBusiness;
        }

        public async Task<ServiceResponseDTO<EnterpriseViewModel>> Create(EnterpriseCreateViewModel enterpriseCreateViewModel)
        {
            ServiceResponseDTO<EnterpriseViewModel> serviceResponseDTO = new ServiceResponseDTO<EnterpriseViewModel>();

            try
            {
                EnterpriseDTO enterpriseDTO = _mapper.Map<EnterpriseDTO>(enterpriseCreateViewModel);

                enterpriseDTO = await _iEnterpriseBusiness.Create(enterpriseDTO);

                serviceResponseDTO.GenericData = _mapper.Map<EnterpriseViewModel>(enterpriseDTO);
                serviceResponseDTO.StatusCode = Convert.ToInt32(HttpStatusCode.Created);
                serviceResponseDTO.Message = CreatedMessages.Adress;
                serviceResponseDTO.Sucess = true;

                await _iWorkUnit.SaveChangesAsync();
                await _iWorkUnit.CommitAsync();
            }
            catch (CustomException ex)
            {
                this._iWorkUnit.Rollback();

                serviceResponseDTO = CatchCustom.ServiceResponse<CustomException, EnterpriseViewModel>(ex, ex.StatusCode);
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

        public async Task<ServiceResponseDTO<EnterpriseViewModel>> Read(Guid id)
        {
            ServiceResponseDTO<EnterpriseViewModel> serviceResponseDTO = new ServiceResponseDTO<EnterpriseViewModel>();

            try
            {
                EnterpriseDTO enterpriseDTO = await _iEnterpriseBusiness.Read(id);

                serviceResponseDTO.GenericData = _mapper.Map<EnterpriseViewModel>(enterpriseDTO);
                serviceResponseDTO.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                serviceResponseDTO.Message = OkMessages.OkMessage;
                serviceResponseDTO.Sucess = true;

            }
            catch (CustomException ex)
            {
                this._iWorkUnit.Rollback();

                serviceResponseDTO = CatchCustom.ServiceResponse<CustomException, EnterpriseViewModel>(ex, ex.StatusCode);
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

        public async Task<ServiceResponseDTO<EnterpriseViewModel>> Update(EnterpriseUpdateViewModel enterpriseUpdateViewModel, Guid id)
        {
            ServiceResponseDTO<EnterpriseViewModel> serviceResponseDTO = new ServiceResponseDTO<EnterpriseViewModel>();

            try
            {
                EnterpriseDTO enterpriseDTO = _mapper.Map<EnterpriseDTO>(enterpriseUpdateViewModel);

                enterpriseDTO = await _iEnterpriseBusiness.Update(enterpriseDTO, id);

                serviceResponseDTO.GenericData = _mapper.Map<EnterpriseViewModel>(enterpriseDTO);
                serviceResponseDTO.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                serviceResponseDTO.Message = OkMessages.OkMessage;
                serviceResponseDTO.Sucess = true;

                await _iWorkUnit.SaveChangesAsync();
                await _iWorkUnit.CommitAsync();
            }
            catch (CustomException ex)
            {
                this._iWorkUnit.Rollback();

                serviceResponseDTO = CatchCustom.ServiceResponse<CustomException, EnterpriseViewModel>(ex, ex.StatusCode);
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

        public async Task<ServiceResponseDTO<EnterpriseViewModel>> Delete(Guid id)
        {
            ServiceResponseDTO<EnterpriseViewModel> serviceResponseDTO = new ServiceResponseDTO<EnterpriseViewModel>();

            try
            {
                EnterpriseDTO enterpriseDTO = await _iEnterpriseBusiness.Delete(id);

                serviceResponseDTO.GenericData = _mapper.Map<EnterpriseViewModel>(enterpriseDTO);
                serviceResponseDTO.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                serviceResponseDTO.Message = OkMessages.OkMessage;
                serviceResponseDTO.Sucess = true;

                await _iWorkUnit.SaveChangesAsync();
                await _iWorkUnit.CommitAsync();
            }
            catch (CustomException ex)
            {
                this._iWorkUnit.Rollback();

                serviceResponseDTO = CatchCustom.ServiceResponse<CustomException, EnterpriseViewModel>(ex, ex.StatusCode);
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
