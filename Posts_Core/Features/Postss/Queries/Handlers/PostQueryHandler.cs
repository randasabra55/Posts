using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Posts_Core.Bases;
using Posts_Core.Features.Postss.Queries.Models;
using Posts_Core.Features.Postss.Queries.Results;
using Posts_Core.Wrapper;
using Posts_Data.Entities.Identity;
using Posts_Services.Abstracts;
using System.Security.Claims;

namespace Posts_Core.Features.Postss.Queries.Handlers
{
    public class PostQueryHandler : ResponseHandler,
                                  IRequestHandler<GetPostByIdQuery, Response<GetPostsForUserResult>>,
                                  IRequestHandler<GetAllPostsQuery, PaginatedResult<GetAllPostsResult>>,
                                  IRequestHandler<GetAllPostsForUserQuery, PaginatedResult<GetPostsForUserResult>>
    {
        IMapper mapper;
        IPostService postService;
        UserManager<User> userManager;
        IHttpContextAccessor httpContextAccessor;
        public PostQueryHandler(IPostService postService, IMapper mapper, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this.postService = postService;
            this.mapper = mapper;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response<GetPostsForUserResult>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await postService.GetPostByIdAsync(request.postId);
            if (post == null)
                return NotFound<GetPostsForUserResult>("post not found");
            var result = mapper.Map<GetPostsForUserResult>(post);
            return Success(result);
        }

        public async Task<PaginatedResult<GetAllPostsResult>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = postService.GetAllPosts();
            var result = await mapper.ProjectTo<GetAllPostsResult>(posts)
                             .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return result;
        }

        public async Task<PaginatedResult<GetPostsForUserResult>> Handle(GetAllPostsForUserQuery request, CancellationToken cancellationToken)
        {
            var userId = httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var user = userManager.Users.FirstOrDefault(u => u.Id == userId);

            var posts = postService.GetAllPostsForUser(userId);
            var result = await mapper.ProjectTo<GetPostsForUserResult>(posts)
                                    .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return result;

        }
    }
}
