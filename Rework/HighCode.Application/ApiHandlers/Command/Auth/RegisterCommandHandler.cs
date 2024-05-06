#region

using HighCode.Application.Services;
using HighCode.Domain.ApiRequests.Auth;
using HighCode.Domain.ApiResponses.Auth;
using HighCode.Domain.Responses;
using HighCode.Infrastructure.Entities;
using MediatR;

#endregion

namespace HighCode.Application.ApiHandlers.Command.Auth;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<RegisterCommandResponse>>
{
    private readonly ResponseFactory<RegisterCommandResponse> _responseFactory;
    private readonly UserService _userService;

    public RegisterCommandHandler(UserService userService, ResponseFactory<RegisterCommandResponse> responseFactory)
    {
        _userService = userService;
        _responseFactory = responseFactory;
    }

    public async Task<Result<RegisterCommandResponse>> Handle(RegisterCommand request,
        CancellationToken cancellationToken)
    {
        var user = new User
        {
            Login = request.Login,
            UserName = request.UserName,
            Role = 0
        };
        var result = await _userService.RegisterUser(user, request.Password);
        if (result.Success)
            return _responseFactory.SuccessResponse(new RegisterCommandResponse
            {
                Message = "Успех",
                Success = true,
                Token = result.Token,
                ValidTo = DateTime.UtcNow.Add(TimeSpan.FromMinutes(60)),
                Role = user.Role
            });
        return _responseFactory.BadRequestResponse(result.UserExist
            ? "Пользователь существует"
            : "Не удалось создать пользователя"
        );
    }
}