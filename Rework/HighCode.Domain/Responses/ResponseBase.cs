#region

using System.ComponentModel;

#endregion

namespace HighCode.Domain.Responses;

public class ResponseBase
{
    [DefaultValue("SUCCESS")] public string? Message { get; set; }

    [DefaultValue(true)] public bool Success { get; set; }

    public static ResponseBase SuccessResponse => new()
    {
        Message = "SUCCESS",
        Success = true
    };
}