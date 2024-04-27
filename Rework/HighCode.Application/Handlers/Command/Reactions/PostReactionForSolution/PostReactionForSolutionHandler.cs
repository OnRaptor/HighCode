using HighCode.Application.Repositories;
using HighCode.Application.Responses;
using HighCode.Application.Services;
using MediatR;

namespace HighCode.Application.Handlers.Command.Reactions.PostReactionForSolution;

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