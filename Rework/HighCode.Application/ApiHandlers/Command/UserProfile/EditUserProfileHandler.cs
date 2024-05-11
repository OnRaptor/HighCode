using HighCode.Application.Repositories;
using HighCode.Application.Services;
using HighCode.Domain.ApiRequests.UserProfile;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Command.UserProfile;

public class EditUserProfileHandler(
    UserRepository userRepository,
    CorrelationContext correlationContext,
    ResponseFactory<SimpleResponse> responseFactory)
    : IRequestHandler<EditUserProfileCommand, Result<SimpleResponse>>
{
    public async Task<Result<SimpleResponse>> Handle(EditUserProfileCommand request,
        CancellationToken cancellationToken)
    {
        var userProfile = await userRepository.GetUserByIdAsync(correlationContext.GetUserId().GetValueOrDefault());
        if (userProfile == null) return responseFactory.BadRequestResponse("Не удается найти пользователя");
        if (!string.IsNullOrWhiteSpace(request.Description))
            userProfile.Description = request.Description;
        if (!string.IsNullOrWhiteSpace(request.UserName))
            userProfile.UserName = request.UserName;

        await userRepository.UpdateUserAsync(userProfile);
        return responseFactory.SuccessResponse(new SimpleResponse
        {
            Message = "Изменения сохранены"
        });
    }
}