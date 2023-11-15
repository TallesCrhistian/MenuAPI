using MenuAPI.Shared.DTOs;
using System.Net;

namespace MenuAPI.Shared.Exceptions
{
    public static class CatchCustom
    {
        public static ServiceResponseDTO<TEntity> ServiceResponse<TException, TEntity>(TException ex, HttpStatusCode statusCode) where TException : Exception
        {
            ServiceResponseDTO<TEntity> serviceResponseDTO = new ServiceResponseDTO<TEntity>();

            serviceResponseDTO.Sucess = false;
            serviceResponseDTO.Message = ex.Message;
            serviceResponseDTO.StatusCode = (int)statusCode;

            return serviceResponseDTO;
        }

    }
}
