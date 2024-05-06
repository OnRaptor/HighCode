#region

using HighCode.Application.Services;
using HighCode.Domain.ApiRequests.Auth;
using HighCode.Domain.ApiResponses.Auth;
using HighCode.Domain.Responses;
using MediatR;

#endregion

namespace HighCode.Application.ApiHandlers.Command.Auth;

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
                Token = result.token,
                Success = true,
                ValidTo = DateTime.UtcNow.Add(TimeSpan.FromMinutes(60)),
                Role = result.role.GetValueOrDefault()
            });

        return _responseFactory.BadRequestResponse(result.message);
    }
}