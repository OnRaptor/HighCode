using HighCode.Application.Repositories;
using HighCode.Domain.ApiRequests.Admin;
using HighCode.Domain.Responses;
using HighCode.Infrastructure.Entities;
using MediatR;

namespace HighCode.Application.ApiHandlers.Queries.Admin;

public class AddStoreValueHandler(
    StoreValuesRepository repository,
    ResponseFactory<SimpleResponse> responseFactory)
    : IRequestHandler<AddStoreValueCommand, Result<SimpleResponse>>
{
    public async Task<Result<SimpleResponse>> Handle(AddStoreValueCommand request, CancellationToken cancellationToken)
    {
        await repository.AddStoreValue(new StoreValue
        {
            Type = request.Type,
            Value = request.Value
        });
        return responseFactory.SuccessResponse(new SimpleResponse
        {
            Message = "Справочник успешно добавлен"
        });
    }
}