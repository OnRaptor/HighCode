using HighCode.Application.Repositories;
using HighCode.Domain.ApiRequests.UserProfile;
using HighCode.Domain.Constants;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Command.UserProfile;

public class BanUserHandler(
    UserRepository userRepository,
    ResponseFactory<SimpleResponse> responseFactory)
    : IRequestHandler<BanUserCommand, Result<SimpleResponse>>
{
    public async Task<Result<SimpleResponse>> Handle(BanUserCommand request, CancellationToken cancellationToken)
    {
        var userToBan = await userRepository.GetUserByIdAsync(request.UserId);
        if (userToBan == null) return responseFactory.BadRequestResponse("Не удалось найти пользователя");
        userToBan.Role = UserRoleTypes.Banned;
        if (await userRepository.UpdateUserAsync(userToBan))
            return responseFactory.SuccessResponse(new SimpleResponse { Message = "Пользователь заблокирован" });

        return responseFactory.ConflictResponse("Не удалось заблокировать пользователя");
    }
}