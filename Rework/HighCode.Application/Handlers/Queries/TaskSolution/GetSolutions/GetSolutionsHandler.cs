using HighCode.Application.Repositories;
using HighCode.Application.Responses;
using HighCode.Domain.DTO;
using MediatR;

namespace HighCode.Application.Handlers.Queries.TaskSolution.GetSolutions;

public class GetSolutionsHandler(
    SolutionRepository repository,
    ReactionRepository reactionRepository,
    ResponseFactory<GetSolutionsResponse> responseFactory)
    : IRequestHandler<GetSolutionsQuery, Result<GetSolutionsResponse>>
{
    public async Task<Result<GetSolutionsResponse>> Handle(GetSolutionsQuery request, CancellationToken cancellationToken)
    {
        var solutions = await repository.GetSolutions();
        return responseFactory.SuccessResponse(new()
        {
            Solutions = await Task.WhenAll(solutions.Select(async x => new SolutionDTO()
            {
                Code = x.Code,
                Id = x.Id,
                IsPublished = null,
                IsTested = null,
                SolutionReactions = await reactionRepository.GetReactionsForSolution(x.Id),
                AuthorName = x.Author.UserName
            }))
        });
    }
}