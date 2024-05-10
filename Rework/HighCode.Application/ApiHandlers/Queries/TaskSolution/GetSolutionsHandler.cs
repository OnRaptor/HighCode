using AutoMapper;
using HighCode.Application.Repositories;
using HighCode.Application.Services;
using HighCode.Domain.ApiRequests.Solutions;
using HighCode.Domain.ApiResponses.Solutions;
using HighCode.Domain.DTO;
using HighCode.Domain.Responses;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HighCode.Application.ApiHandlers.Queries.TaskSolution;

public class GetSolutionsHandler(
    SolutionRepository repository,
    CorrelationContext correlationContext,
    ResponseFactory<GetSolutionsResponse> responseFactory,
    IMapper mapper,
    IServiceProvider serviceProvider
)
    : IRequestHandler<GetSolutionsQuery, Result<GetSolutionsResponse>>
{
    public async Task<Result<GetSolutionsResponse>> Handle(GetSolutionsQuery request, CancellationToken cancellationToken)
    {
        var solutions = await repository.GetSolutions(request.TaskId);
        return responseFactory.SuccessResponse(new()
        {
            Solutions = await Task.WhenAll(solutions.Select(async x =>
            {
                var reactionRepository = serviceProvider.GetService<ReactionRepository>();
                var solutionDto = mapper.Map<SolutionDTO>(x);
                solutionDto.SolutionReactions = await reactionRepository.GetReactionsForSolution(x.Id);
                solutionDto.MyReaction =
                    await reactionRepository.GetReactionSolutionForUser(x.Id,
                        correlationContext.GetUserId().GetValueOrDefault());
                return solutionDto;
            }))
        });
    }
}