using System.CodeDom.Compiler;
using HighCode.Domain.ApiRequests.Auth;
using HighCode.Domain.ApiRequests.CollectionOfTasks;
using HighCode.Domain.ApiRequests.Comments;
using HighCode.Domain.ApiRequests.Reactions;
using HighCode.Domain.ApiRequests.Solutions;
using HighCode.Domain.ApiRequests.Tasks;
using HighCode.Domain.ApiRequests.UserProfile;
using HighCode.Domain.ApiResponses.Auth;
using HighCode.Domain.ApiResponses.CollectionOfTasks;
using HighCode.Domain.ApiResponses.Comments;
using HighCode.Domain.ApiResponses.Leaderboards;
using HighCode.Domain.ApiResponses.Reactions;
using HighCode.Domain.ApiResponses.Solutions;
using HighCode.Domain.ApiResponses.Tasks;
using HighCode.Domain.ApiResponses.UserProfile;
using HighCode.Domain.DTO;
using HighCode.Domain.Responses;
using Refit;

namespace HighCode.Client
{
    [GeneratedCode("Refitter", "0.9.9.0")]
    public partial interface IHighCodeAPI
    {
        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Post("/api/collectionoftasks/CreateCollection")]
        Task<SimpleResponse> CreateCollection([Body] CreateCollectionCommand body);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Post("/api/collectionoftasks/EditCollection")]
        Task<SimpleResponse> EditCollection([Body] EditCollectionCommand body);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Post("/api/collectionoftasks/AddTasksToCollection")]
        Task<SimpleResponse> AddTasksToCollection([Body] AddTasksToCollectionCommand body);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Post("/api/collectionoftasks/RemoveTaskFromCollection")]
        Task<SimpleResponse> RemoveTaskFromCollection([Body] RemoveTaskFromCollectionCommand body);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Get("/api/collectionoftasks/GetCollections")]
        Task<GetCollectionsResponse> GetCollections([Query] GetCollectionsQuery body);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Get("/api/collectionoftasks/GetTasksInCollection")]
        Task<GetTaskInCollectionResponse> GetTasksInCollection([Query] GetTaskInCollectionQuery body);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Post("/api/comments/PostComment")]
        Task<PostCommentResponse> PostComment([Body] PostCommentCommand body);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Get("/api/comments/GetComments")]
        Task<GetCommentsResponse> GetComments([Query] [AliasAs("TargetTypeForComment")] int? targetTypeForComment,
            [Query] [AliasAs("RelatedTargetId")] Guid? relatedTargetId);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Post("/api/comments/DeleteComment")]
        Task<DeleteCommentResponse> DeleteComment([Query] [AliasAs("Id")] Guid? id);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Get("/api/leaderboard/GetLeaderboard")]
        Task<GetLeaderboardsResponse> GetLeaderboard();

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Get("/api/profile/GetUserProfile")]
        Task<GetUserProfileResponse> GetUserProfile();

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Post("/api/profile/EditProfile")]
        Task<SimpleResponse> EditProfile([Body] EditUserProfileCommand body);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Post("/api/reactions/AddReactionToComment")]
        Task<PostReactionForCommentResponse> AddReactionToComment([Body] PostReactionForCommentCommand body);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Post("/api/reactions/AddReactionToSolution")]
        Task<PostReactionForSolutionResponse> AddReactionToSolution([Body] PostReactionForSolutionCommand body);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Post("/api/solution/SaveSolution")]
        Task<SimpleResponse> SaveSolution([Body] SaveSolutionCommand body);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Post("/api/solution/ChangeSolutionPublish")]
        Task<SimpleResponse> ChangeSolutionPublish([Body] ChangeSolutionPublishCommand body);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Get("/api/solution/GetSolutionForUser")]
        Task<GetSolutionResponse> GetSolutionForUser([Query] [AliasAs("TaskId")] Guid? taskId);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Get("/api/solution/GetSolutions")]
        Task<GetSolutionsResponse> GetSolutions([Query] [AliasAs("TaskId")] Guid? taskId);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Post("/api/solution/TestCode")]
        Task<TestCodeResponse> TestCode([Body] TestCodeCommand body);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Post("/api/tasks/CreateTask")]
        Task<SimpleResponse> CreateTask([Body] TaskDTO body);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Post("/api/tasks/GetTasks")]
        Task<GetAllTaskResponse> GetTasks([Body] GetAllTaskQuery body);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Get("/api/tasks/GetTask")]
        Task<GetTaskByIdResponse> GetTask([Query] [AliasAs("Id")] Guid? id);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Post("/api/tasks/EditTask")]
        Task<SimpleResponse> EditTask([Body] EditTaskCommand body);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Get("/api/tasks/GetPopularTasks")]
        Task<GetPopularTasksResponse> GetPopularTasks([Query] GetPopularTasksQuery query);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Post("/api/user/Login")]
        Task<LoginCommandResponse> Login([Body] LoginCommand body);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Post("/api/user/Register")]
        Task<RegisterCommandResponse> Register([Body] RegisterCommand body);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">
        /// Thrown when the request returns a non-success status code:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>409</term>
        /// <description>Conflict</description>
        /// </item>
        /// </list>
        /// </exception>
        [Headers("Accept: application/json")]
        [Post("/api/user/BanUser")]
        Task<SimpleResponse> BanUser([Body] BanUserCommand body);


    }
}