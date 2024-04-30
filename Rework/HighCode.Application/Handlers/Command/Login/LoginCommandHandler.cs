#region

using HighCode.Application.Responses;
using HighCode.Application.Services;
using MediatR;

#endregion

namespace HighCode.Application.Handlers.Command.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
{
    private readonly ResponseFactory<LoginCommandResponse> _responseFactory;
    private readonly UserService _userService;

    public LoginCommandHandler(UserService userService, ResponseFactory<LoginCommandResponse> responseFactory)
    {
        _userService = userService;
        _responseFactory = responseFactory;
    }

    public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var result = await _userService.LoginUser(request.Login, request.Password);
        if (result.success)
            return _responseFactory.SuccessResponse(new LoginCommandResponse
            {
                Message = "Успех!",
                Token = result.token,
                Success = true,
                ValidTo = DateTime.UtcNow.Add(TimeSpan.FromMinutes(60))
            });

        return _responseFactory.BadRequestResponse(result.message);
    }
}