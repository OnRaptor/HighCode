using AutoMapper;
using HighCode.Application.Repositories;
using HighCode.Domain.ApiRequests.Admin;
using HighCode.Domain.ApiResponses.Admin;
using HighCode.Domain.DTO;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Queries.Admin;

public class GetStoreValuesHandler(
    StoreValuesRepository storeValuesRepository,
    IMapper mapper,
    ResponseFactory<GetStoreValuesResponse> responseFactory)
    : IRequestHandler<GetStoreValuesQuery, Result<GetStoreValuesResponse>>
{
    public async Task<Result<GetStoreValuesResponse>> Handle(GetStoreValuesQuery request,
        CancellationToken cancellationToken)
    {
        if (request.StoreId.HasValue)
            return responseFactory.SuccessResponse(new GetStoreValuesResponse
            {
                StoreValues =
                    [mapper.Map<StoreValueDTO>(await storeValuesRepository.GetStoreValue(request.StoreId.Value))]
            });

        if (request.Type.HasValue)
            return responseFactory.SuccessResponse(new GetStoreValuesResponse
            {
                StoreValues =
                    (await storeValuesRepository.GetStoreValuesByType(request.Type.Value))
                    .Select(mapper.Map<StoreValueDTO>).ToList()
            });

        return responseFactory.SuccessResponse(new GetStoreValuesResponse
        {
            StoreValues =
                (await storeValuesRepository.GetAllStoreValues())
                .Select(mapper.Map<StoreValueDTO>).ToList()
        });
    }
}