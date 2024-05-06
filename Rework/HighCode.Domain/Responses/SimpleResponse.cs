namespace HighCode.Domain.Responses;

public class SimpleResponse : ResponseBase
{
    public object? Content { get; set; } = null;
}