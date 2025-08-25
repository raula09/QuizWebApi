﻿namespace QuizWebApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string?> RegisterAsync(RegisterRequest request);
        Task<string?> LoginAsync(LoginRequest request);
    }
}
