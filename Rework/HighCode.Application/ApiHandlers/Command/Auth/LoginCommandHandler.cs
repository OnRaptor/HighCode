#region

using HighCode.Application.Repositories;
using HighCode.Application.Services;
using HighCode.Domain.ApiRequests.Auth;
using HighCode.Domain.ApiResponses.Auth;
using HighCode.Domain.Responses;
using MediatR;

#endregion

namespace HighCode.Application.ApiHandlers.Command.Auth;

public class LoginCommandHandler(
    UserService userService,
    UserRepository userRepository,
    ResponseFactory<LoginCommandResponse> responseFactory)
    : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
{
    public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var result = await userService.LoginUser(request.Login, request.Password);
        if (result.success)
            return responseFactory.SuccessResponse(new LoginCommandResponse
            {
                Token = result.token,
                Success = true,
                ValidTo = DateTime.UtcNow.Add(TimeSpan.FromMinutes(60)),
                Role = result.role.GetValueOrDefault()
            });

        return responseFactory.BadRequestResponse(result.message);
    }
}