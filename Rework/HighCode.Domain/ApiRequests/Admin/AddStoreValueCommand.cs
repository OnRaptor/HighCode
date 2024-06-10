using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.Admin;

public class AddStoreValueCommand : IRequest<Result<SimpleResponse>>
{
    public int Type { get; set; }
    public string Value { get; set; }
}