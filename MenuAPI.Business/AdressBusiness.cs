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
    public class AdressBusiness : IAdressBusiness
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository _iBaseRepository;

        public AdressBusiness(IMapper mapper, IBaseRepository iBaseRepository)
        {
            _mapper = mapper;
            _iBaseRepository = iBaseRepository;
        }

        public async Task<AdressDTO> Create(AdressDTO adressDTO)
        {
            adressDTO.CreatedAt = DateTime.Now.ToUniversalTime();

            Adress adress = _mapper.Map<Adress>(adressDTO);

            adress = await _iBaseRepository.Create(adress);

            adressDTO = (adress is not null) ? _mapper.Map<AdressDTO>(adress)
                : throw new CustomException(HttpStatusCode.BadRequest, BadRequestMessages.AdressNoCreated, new HttpRequestException());

            return adressDTO;
        }

        public async Task<AdressDTO> Read(Guid id)
        {
            Adress adress = await _iBaseRepository.Read<Adress>(id);

            AdressDTO adressDTO = adress is not null ? _mapper.Map<AdressDTO>(adress)
                : throw new CustomException(HttpStatusCode.NotFound, NotFoundMessages.Adress, new HttpRequestException());

            return adressDTO;
        }

        public async Task<AdressDTO> Update(AdressDTO adressDTO, Guid id)
        {
            Adress adress = await _iBaseRepository.Read<Adress>(id);

            if (adress is not null)
            {
                adress = _mapper.Map<Adress>(adressDTO);

                adress.UpdatedAt = DateTime.Now.ToUniversalTime();
                adress.Id = id;

                adress = await _iBaseRepository.Update(adress);

                adressDTO = adress is not null ? _mapper.Map<AdressDTO>(adress)
                    : throw new CustomException(HttpStatusCode.BadRequest, BadRequestMessages.AdressNoUpdate, new HttpRequestException());

                return adressDTO;
            }
            else
            {
                throw new CustomException(HttpStatusCode.NotFound, NotFoundMessages.Adress, new HttpRequestException());
            }
        }


        public async Task<AdressDTO> Delete(Guid id)
        {
            Adress adress = await _iBaseRepository.Read<Adress>(id);


            adress = adress is not null ? await _iBaseRepository.Delete<Adress>(id) :

             throw new CustomException(HttpStatusCode.NotFound, NotFoundMessages.Adress, new HttpRequestException());


            AdressDTO adressDTO = _mapper.Map<AdressDTO>(adress);

            return adressDTO;
        }
    }
}
