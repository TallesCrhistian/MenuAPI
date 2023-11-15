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
    public class EnterpriseBusiness : IEnterpriseBusiness
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository _iBaseRepository;

        public EnterpriseBusiness(IMapper mapper, IBaseRepository iBaseRepository)
        {
            _mapper = mapper;
            _iBaseRepository = iBaseRepository;
        }

        public async Task<EnterpriseDTO> Create(EnterpriseDTO enterpriseDTO)
        {
            enterpriseDTO.CreatedAt = DateTime.Now.ToUniversalTime();

            Enterprise enterprise = _mapper.Map<Enterprise>(enterpriseDTO);

            enterprise = await _iBaseRepository.Create(enterprise);

            enterpriseDTO = (enterprise is not null) ? _mapper.Map<EnterpriseDTO>(enterprise)
                : throw new CustomException(HttpStatusCode.BadRequest, BadRequestMessages.EnterpriseNoCreated, new HttpRequestException());

            return enterpriseDTO;
        }

        public async Task<EnterpriseDTO> Read(Guid id)
        {
            Enterprise enterprise = await _iBaseRepository.Read<Enterprise>(id);

            EnterpriseDTO enterpriseDTO = enterprise is not null ? _mapper.Map<EnterpriseDTO>(enterprise)
                : throw new CustomException(HttpStatusCode.NotFound, NotFoundMessages.Enterprise, new HttpRequestException());

            return enterpriseDTO;
        }

        public async Task<EnterpriseDTO> Update(EnterpriseDTO enterpriseDTO, Guid id)
        {

            Enterprise enterprise = await _iBaseRepository.Read<Enterprise>(id);

            if (enterprise is not null)
            {
                enterprise = _mapper.Map<Enterprise>(enterpriseDTO);

                enterprise.UpdatedAt = DateTime.Now.ToUniversalTime();
                enterprise.Id = id;

                enterprise = await _iBaseRepository.Update(enterprise);

                enterpriseDTO = enterprise is not null ? _mapper.Map<EnterpriseDTO>(enterprise)
                    : throw new CustomException(HttpStatusCode.BadRequest, BadRequestMessages.EnterpriseNoCreated, new HttpRequestException());

                return enterpriseDTO;
            }
            else
            {
                throw new CustomException(HttpStatusCode.NotFound, NotFoundMessages.Enterprise, new HttpRequestException());
            }
        }

        public async Task<EnterpriseDTO> Delete(Guid id)
        {
            Enterprise enterprise = await _iBaseRepository.Read<Enterprise>(id);

            if (enterprise is not null)
            {
                await _iBaseRepository.Delete<Enterprise>(id);
            }
            else
            {
                throw new CustomException(HttpStatusCode.NotFound, NotFoundMessages.Enterprise, new HttpRequestException());
            }

            EnterpriseDTO enterpriseDTO = _mapper.Map<EnterpriseDTO>(enterprise);

            return enterpriseDTO;
        }
    }
}
