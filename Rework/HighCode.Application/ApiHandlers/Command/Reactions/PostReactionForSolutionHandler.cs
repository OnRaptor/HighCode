using HighCode.Application.Repositories;
using HighCode.Application.Services;
using HighCode.Domain.ApiRequests.Reactions;
using HighCode.Domain.ApiResponses.Reactions;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Command.Reactions;

public class PostReactionForSolutionHandler(
    ResponseFactory<PostReactionForSolutionResponse> responseFactory,
    CorrelationContext correlationContext,
    ReactionRepository repository
    )
    : IRequestHandler<PostReactionForSolutionCommand, Result<PostReactionForSolutionResponse>>
{
    public async Task<Result<PostReactionForSolutionResponse>> Handle(PostReactionForSolutionCommand request, CancellationToken cancellationToken)
    {
        var userId = correlationContext.GetUserId().GetValueOrDefault();
        if (await repository.ApplyReactionToSolution(
                request.SolutionId,
                request.Reaction,
                userId))
            return responseFactory.SuccessResponse(new()
            {
                SolutionReactions = await repository.GetReactionsForSolution(request.SolutionId)
            });
        

        return responseFactory.BadRequestResponse("Не удалось добавить реакцию на решение");
    }
}