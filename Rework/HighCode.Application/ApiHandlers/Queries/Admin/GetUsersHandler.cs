using AutoMapper;
using HighCode.Application.Repositories;
using HighCode.Domain.ApiRequests.Admin;
using HighCode.Domain.ApiResponses.Admin;
using HighCode.Domain.DTO;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Queries.Admin;

public class GetUsersHandler(
    UserRepository userRepository,
    IMapper mapper,
    ResponseFactory<GetUsersResponse> responseFactory)
    : IRequestHandler<GetUsersQuery, Result<GetUsersResponse>>
{
    public async Task<Result<GetUsersResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.searchQuery))
            return responseFactory.SuccessResponse(new GetUsersResponse
            {
                Users = (await userRepository.GetAllUsers()).Select(mapper.Map<UserDTO>)
            });

        return responseFactory.SuccessResponse(new GetUsersResponse
        {
            Users = (await userRepository.GetAllUsers(request.searchQuery)).Select(mapper.Map<UserDTO>)
        });
    }
}