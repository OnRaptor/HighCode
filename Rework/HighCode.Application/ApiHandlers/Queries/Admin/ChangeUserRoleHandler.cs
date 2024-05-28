using HighCode.Application.Repositories;
using HighCode.Application.Services;
using HighCode.Domain.ApiRequests.Admin;
using HighCode.Domain.Constants;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Queries.Admin;

public class ChangeUserRoleHandler(
    CorrelationContext httpContext,
    UserRepository userRepository,
    ResponseFactory<SimpleResponse> responseFactory)
    : IRequestHandler<ChangeUserRoleCommand, Result<SimpleResponse>>
{
    public async Task<Result<SimpleResponse>> Handle(ChangeUserRoleCommand request, CancellationToken cancellationToken)
    {
        switch ((UserRoleTypes)request.Role)
        {
            case UserRoleTypes.Moderator or UserRoleTypes.Administrator
                when httpContext.GetUserRole() == UserRoleTypes.Administrator:
                await userRepository.ChangeUserRole(request.UserId, (UserRoleTypes)request.Role);
                break;
            case UserRoleTypes.Moderator or UserRoleTypes.Administrator:
                return responseFactory.UnAuthResponse();
            case UserRoleTypes.User or UserRoleTypes.Banned
                when await userRepository.GetUserByIdAsync(request.UserId) is
                         { Role: UserRoleTypes.Moderator or UserRoleTypes.Administrator }
                     && httpContext.GetUserRole() != UserRoleTypes.Administrator:
                return responseFactory.UnAuthResponse();
            default:
                await userRepository.ChangeUserRole(request.UserId, (UserRoleTypes)request.Role);
                break;
        }

        return responseFactory.SuccessResponse(new SimpleResponse
        {
            Message = "Роль успешно изменена"
        });
    }
}