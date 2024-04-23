using HighCode.Application.Responses;
using MediatR;

namespace HighCode.Application.Handlers.Command.Register;

public class RegisterCommand : IRequest<Result<SimpleResponse>>
{
    public string Login { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}