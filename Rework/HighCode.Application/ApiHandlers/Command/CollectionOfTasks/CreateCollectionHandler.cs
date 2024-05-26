using AutoMapper;
using HighCode.Application.Repositories;
using HighCode.Application.Services;
using HighCode.Domain.ApiRequests.CollectionOfTasks;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Command.CollectionOfTasks;

public class CreateCollectionHandler(
    TaskCollectionRepository taskCollectionRepository,
    IMapper mapper,
    CorrelationContext correlationContext,
    ResponseFactory<SimpleResponse> responseFactory)
    : IRequestHandler<CreateCollectionCommand, Result<SimpleResponse>>
{
    public async Task<Result<SimpleResponse>> Handle(CreateCollectionCommand request,
        CancellationToken cancellationToken)
    {
        var collection = mapper.Map<Infrastructure.Entities.CollectionOfTasks>(request.Collection);
        collection.AuthorId = correlationContext.GetUserId().Value;
        if (!await taskCollectionRepository.Create(collection))
            return responseFactory.ConflictResponse("Не удалось создать коллекцию");

        return responseFactory.SuccessResponse(new SimpleResponse { Message = "Задача создана" });
    }
}