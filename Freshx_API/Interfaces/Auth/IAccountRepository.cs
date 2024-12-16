﻿using Freshx_API.Dtos.Auth.Account;
using Freshx_API.Models;

namespace Freshx_API.Interfaces.Auth
{
    public interface IAccountRepository
    {
        public Task<AppUser?> RegisterAccount(AddingRegister registerDto);
        public Task<LoginResponse> LoginAccount(LoginRequest loginRequest);
        public Task<bool> EmailExist (string email);
    }
}
