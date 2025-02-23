﻿#region

using AutoMapper;
using HighCode.Application.Repositories;
using HighCode.Application.Services;
using HighCode.Domain.ApiRequests.Tasks;
using HighCode.Domain.ApiResponses.Tasks;
using HighCode.Domain.Constants;
using HighCode.Domain.DTO;
using HighCode.Domain.Models;
using HighCode.Domain.Responses;
using MediatR;

#endregion

namespace HighCode.Application.ApiHandlers.Queries.CodeTask;

public class GetAllTaskHandler(
    TaskRepository taskRepository,
    ResponseFactory<GetAllTaskResponse> responseFactory,
    CorrelationContext correlationContext,
    IMapper mapper
)
    : IRequestHandler<GetAllTaskQuery, Result<GetAllTaskResponse>>
{
    public async Task<Result<GetAllTaskResponse>> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
    {
        var allTasks = (await taskRepository.GetAllTasks()).ToArray();
        var isModer =
            correlationContext.GetUserRole() != null
            && correlationContext.GetUserRole() != UserRoleTypes.User
            && correlationContext.GetUserRole() != UserRoleTypes.Banned;

        if (!isModer && (GetAllGroupTypes)request.GroupType != GetAllGroupTypes.Default)
            return responseFactory.UnAuthResponse();
        
        switch ((GetAllGroupTypes)request.GroupType)
        {
            case GetAllGroupTypes.Default:
                allTasks = allTasks.Where(x => x is { IsPublished: true, IsSuggested: false }).ToArray();
                break;
            case GetAllGroupTypes.UnPublishedOnly:
                allTasks = allTasks.Where(x => x is { IsPublished: false, IsSuggested: false }).ToArray();
                break;
            case GetAllGroupTypes.SuggestedOnly:
                allTasks = allTasks.Where(x => x.IsSuggested).ToArray();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        if (request.Filters != null)
            foreach (var filter in request.Filters)
            {
                if (string.IsNullOrWhiteSpace(filter.Value)) continue;
                switch (filter.Type)
                {
                    case FilterTypeConstants.ByLanguage:
                    {
                        allTasks = allTasks.Where(x => x.ProgrammingLanguage == filter.Value).ToArray();
                        break;
                    }
                    case FilterTypeConstants.ByComplexity:
                    {
                        if (int.TryParse(filter.Value, out var val))
                            allTasks = allTasks.Where(x => x.Complexity == val).ToArray();
                        break;
                    }
                    case FilterTypeConstants.ByCategory:
                        allTasks = allTasks.Where(t => t.Category != null)
                            .Where(t => t.Category.ToLower().Trim().Contains(filter.Value.ToLower())).ToArray();
                        break;
                }
            }

        if (!string.IsNullOrWhiteSpace(request.SearchQuery))
            allTasks = allTasks
                .Where(
                    x => (x.Title.ToLower() + " " + x.Description.ToLower())
                        .Contains(request.SearchQuery))
                .ToArray();

        return responseFactory.SuccessResponse(new GetAllTaskResponse
        {
            Tasks = allTasks.OrderByDescending(x => x.CreateDate).Select(mapper.Map<TaskDTO>)
        });
    }
}