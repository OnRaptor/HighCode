using HighCode.Application.Repositories;
using HighCode.Domain.ApiRequests.Admin;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Queries.Admin;

public class DeleteStoreValueHandler(
    StoreValuesRepository repository,
    ResponseFactory<SimpleResponse> responseFactory)
    : IRequestHandler<DeleteStoreValueCommand, Result<SimpleResponse>>
{
    public async Task<Result<SimpleResponse>> Handle(DeleteStoreValueCommand request,
        CancellationToken cancellationToken)
    {
        await repository.DeleteStoreValue(request.StoreId);
        return responseFactory.SuccessResponse(new SimpleResponse
        {
            Message = "Справочник удален"
        });
    }
}