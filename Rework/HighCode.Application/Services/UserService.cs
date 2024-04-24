#region

using System.Security.Cryptography;
using System.Text;
using HighCode.Application.Common;
using HighCode.Application.Models;
using HighCode.Application.Repositories;
using HighCode.Infrastructure.Entities;

#endregion

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
        var result = await _userRepository.CreateUserAsync(user);
        result.Token = JwtGenerator.GenerateToken(user.Id.ToString(), user.UserName, user.Role);
        return result;
    }

    public async Task<LoginUserResult> LoginUser(string login, string password)
    {
        var user = await _userRepository.FindUserByLogin(login);
        if (user == null)
        {
            return new LoginUserResult(
                false,
                message: $"Пользователь с логином {login} не найден");
        }
        else
        {
            var hmac = new HMACSHA256(user.PasswordSalt);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            var result = true;
            for (var i = 0; i < hash.Length; i++)
                if (hash[i] != user.PasswordHash[i])
                    result = false;

            if (!result) return new LoginUserResult(false, message: "Пароль не верный");


            var token = JwtGenerator.GenerateToken(user.Id.ToString(), user.UserName, user.Role ?? "User");
            return new LoginUserResult(result, token);
        }
    }
}