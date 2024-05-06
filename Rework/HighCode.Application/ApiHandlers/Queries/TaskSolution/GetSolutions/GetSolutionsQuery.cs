using HighCode.Application.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Queries.TaskSolution.GetSolutions;

public class GetSolutionsQuery : IRequest<Result<GetSolutionsResponse>>
{

}