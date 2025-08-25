using QuizWebApi.Models;
using QuizWebApi.Repositories.Interfaces;
using QuizWebApi.Services.Interfaces;
using QuizWebApi.Utils;

namespace QuizWebApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _users;
        private readonly JwtTokenGenerator _jwt;

        public AuthService(IUserRepository users, JwtTokenGenerator jwt)
        {
            _users = users;
            _jwt = jwt;
        }

        public async Task<string?> RegisterAsync(RegisterRequest request)
        {
            var existing = await _users.GetByEmailAsync(request.Email);
            if (existing != null) return null;

            var user = new User
            {
                Email = request.Email,
                Username = request.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            await _users.CreateAsync(user);

            return _jwt.GenerateToken(user);
        }

        public async Task<string?> LoginAsync(LoginRequest request)
        {
            var user = await _users.GetByEmailAsync(request.Email);
            if (user == null) return null;

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                return null;

            return _jwt.GenerateToken(user);
        }
    }
}
