using HighCode.Domain.Constants;

namespace HighCode.Infrastructure.Entities;

public class StoreValue
{
    public Guid Id { get; set; }
    public StoreValueType Type { get; set; }
    public string Value { get; set; }
}