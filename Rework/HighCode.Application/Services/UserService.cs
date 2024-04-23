using System.Security.Cryptography;
using System.Text;
using HighCode.Application.Common;
using HighCode.Application.Models;
using HighCode.Application.Repositories;
using HighCode.Infrastructure.Entities;

namespace HighCode.Application.Services;

public class UserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// Создает пользователя на основе User и пароля
    /// </summary>
    /// <returns>Сообщение с результатом</returns>
    public async Task<CreateUserResult> RegisterUser(User user, string password)
    {
        var hmac = new HMACSHA256();
        user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        user.PasswordSalt = hmac.Key;

        return await _userRepository.CreateUserAsync(user);
    }

    public async Task<LoginUserResult> LoginUser(string login, string password)
    {
        var user = await _userRepository.FindUserByLogin(login);
        if (user == null)
            return new(
                false, 
                message: $"Пользователь с логином {login} не найден");
        else
        {
            var hmac = new HMACSHA256(user.PasswordSalt);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            var result = true;
            for (var i = 0; i < hash.Length; i++)
            {
                if (hash[i] != user.PasswordHash[i])
                {
                    result = false;
                }
            }

            if (!result) return new(false, message: "Пароль не верный");
            
            
            var token = JwtGenerator.GenerateToken(user.Id.ToString(), user.UserName);
            return new(result, token);
        }
    }
}