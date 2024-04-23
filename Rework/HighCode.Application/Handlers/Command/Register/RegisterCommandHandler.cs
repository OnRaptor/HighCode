using HighCode.Application.Responses;
using HighCode.Application.Services;
using HighCode.Infrastructure.Entities;
using MediatR;

namespace HighCode.Application.Handlers.Command.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<SimpleResponse>>
{
    private readonly UserService _userService;
    private readonly ResponseFactory<SimpleResponse> _responseFactory;

    public RegisterCommandHandler(UserService userService, ResponseFactory<SimpleResponse> responseFactory)
    {
        _userService = userService;
        _responseFactory = responseFactory;
    }

    public async Task<Result<SimpleResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Login = request.Login,
            UserName = request.UserName
        };
        var result = await _userService.RegisterUser(user, request.Password);
        if (result.Success)
            return  _responseFactory.SuccessResponse(new(){ Message = "Успех", Success = true });
        return _responseFactory.ConflictResponse( result.UserExist
            ? "Пользователь существует"
            : "Не удалось создать пользователя"
        );
    }
}