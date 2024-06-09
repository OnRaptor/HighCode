using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.Admin;

public class DeleteStoreValueCommand : IRequest<Result<SimpleResponse>>
{
    public Guid StoreId { get; set; }
}