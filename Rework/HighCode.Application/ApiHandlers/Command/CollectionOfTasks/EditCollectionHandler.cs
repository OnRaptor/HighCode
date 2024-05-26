using AutoMapper;
using HighCode.Application.Repositories;
using HighCode.Domain.ApiRequests.CollectionOfTasks;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Command.CollectionOfTasks;

public class EditCollectionHandler(
    TaskCollectionRepository taskCollectionRepository,
    IMapper mapper,
    ResponseFactory<SimpleResponse> responseFactory)
    : IRequestHandler<EditCollectionCommand, Result<SimpleResponse>>
{
    public async Task<Result<SimpleResponse>> Handle(EditCollectionCommand request, CancellationToken cancellationToken)
    {
        var collection = await taskCollectionRepository.GetById(request.Collection.Id);
        if (collection == null) return responseFactory.BadRequestResponse("Не удалось обновить коллекцию");
        var newCollection = mapper.Map<Infrastructure.Entities.CollectionOfTasks>(request.Collection);
        newCollection.AuthorId = collection.AuthorId;
        if (!await taskCollectionRepository.Update(newCollection))
            return responseFactory.ConflictResponse("Не удалось обновить коллекцию");
        return responseFactory.SuccessResponse(new SimpleResponse { Message = "Коллекция обновлена" });
    }
}