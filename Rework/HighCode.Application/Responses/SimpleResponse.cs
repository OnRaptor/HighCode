namespace HighCode.Application.Responses;

public class SimpleResponse : ResponseBase
{
    public object? Content { get; set; } = null;
}