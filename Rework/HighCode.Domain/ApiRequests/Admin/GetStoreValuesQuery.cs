using HighCode.Domain.ApiResponses.Admin;
using HighCode.Domain.Constants;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.Admin;

public class GetStoreValuesQuery : IRequest<Result<GetStoreValuesResponse>>
{
    public StoreValueType? Type { get; set; }
    public Guid? StoreId { get; set; }
}