﻿using MenuAPI.Shared.DTOs;
using MenuAPI.Shared.ViewModels.User;

namespace MenuAPI.Identity.Interfaces
{
    public interface IIdentityServices
    {
        Task<ServiceResponseDTO<UserViewModel>> CreateUser(UserCreateViewModel userCreateViewModel);
        Task<UserLoginResponseDTO> Login(UserLoginViewModel userLogin);
        Task<UserLoginResponseDTO> LoginNoPassword(string userId);
    }
}