using AutoMapper;
using HighCode.Domain.Constants;
using HighCode.Domain.DTO;
using HighCode.Infrastructure.Entities;

namespace HighCode.Application.Common;

public class AppMapperProfile : Profile
{
    public AppMapperProfile()
    {
        CreateMap<CodeTask, TaskDTO>()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.UserName));
        ;
        CreateMap<TaskDTO, CodeTask>();
        CreateMap<CodeTaskSolution, SolutionDTO>()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.UserName));
        CreateMap<Comment, CommentDTO>()
            .ForMember(dest => dest.IsAuthorBanned, opt => opt.MapFrom(src => src.Author.Role == UserRoleTypes.Banned))
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.UserName));
        CreateMap<Leaderboard, LeaderboardDTO>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.UserName));
        CreateMap<Leaderboard, LeaderboardDTO>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.UserName));
        CreateMap<CollectionOfTasksDTO, CollectionOfTasks>();
        CreateMap<CollectionOfTasks, CollectionOfTasksDTO>();
        CreateMap<User, UserDTO>();
        CreateMap<UserDTO, User>();
    }
}