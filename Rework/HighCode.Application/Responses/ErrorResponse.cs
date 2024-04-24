#region

using System.ComponentModel;
using System.Text.Json;

#endregion

namespace HighCode.Application.Responses;

public class ErrorResponse
{
    [DefaultValue("ERROR_MESSAGE")] public string ErrorMessage { get; init; }

    [DefaultValue(false)] public bool Success { get; init; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(
            this,
            new JsonSerializerOptions(JsonSerializerDefaults.Web));
    }
}