﻿namespace Freshx_API.Dtos.Auth.Account
{
    public class VerifyCodeRequest
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
}
