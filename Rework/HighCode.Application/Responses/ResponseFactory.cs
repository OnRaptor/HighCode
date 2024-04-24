#region

using System.Net;

#endregion

namespace HighCode.Application.Responses;

public class ResponseFactory<TResponse> where TResponse : ResponseBase
{
    public Result<TResponse> ConflictResponse(string message)
    {
        return new Result<TResponse>
        {
            Error = new ErrorResponse
            {
                ErrorMessage = message,
                Success = false
            },
            Response = null,
            StatusCode = HttpStatusCode.Conflict
        };
    }

    public Result<TResponse> BadRequestResponse(string message)
    {
        return new Result<TResponse>
        {
            Error = new ErrorResponse
            {
                ErrorMessage = message,
                Success = false
            },
            Response = null,
            StatusCode = HttpStatusCode.BadRequest
        };
    }

    public Result<TResponse> SuccessResponse(TResponse response)
    {
        response.Success = true;
        return new Result<TResponse>
        {
            Error = null,
            Response = response,
            StatusCode = HttpStatusCode.OK
        };
    }
}