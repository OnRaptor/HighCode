using HighCode.Domain.Constants;

namespace HighCode.Domain.DTO;

public class StoreValueDTO
{
    public Guid Id { get; set; }
    public StoreValueType Type { get; set; }
    public string Value { get; set; }
}