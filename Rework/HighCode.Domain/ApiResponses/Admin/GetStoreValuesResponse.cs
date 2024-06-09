using HighCode.Domain.DTO;
using HighCode.Domain.Responses;

namespace HighCode.Domain.ApiResponses.Admin;

public class GetStoreValuesResponse : ResponseBase
{
    public List<StoreValueDTO> StoreValues { get; set; }
}