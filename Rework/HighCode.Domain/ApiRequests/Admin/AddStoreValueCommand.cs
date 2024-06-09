using HighCode.Domain.Constants;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.Admin;

public class AddStoreValueCommand : IRequest<Result<SimpleResponse>>
{
    public StoreValueType Type { get; set; }
    public string Value { get; set; }
}