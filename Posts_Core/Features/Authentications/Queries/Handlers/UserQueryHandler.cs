using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Posts_Core.Bases;
using Posts_Core.Features.Authentications.Queries.Models;
using Posts_Core.Features.Authentications.Queries.Results;
using Posts_Core.Wrapper;
using Posts_Data.Entities.Identity;
using System.Security.Claims;

namespace Posts_Core.Features.Authentications.Queries.Handlers
{
    public class UserQueryHandler : ResponseHandler,
                                   IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>,
                                   IRequestHandler<GetUserPaginatedQuery, PaginatedResult<GetUserPaginatedList>>
    {
        IMapper mapper;
        UserManager<User> userManager;
        IHttpContextAccessor httpContextAccessor;
        public UserQueryHandler(IMapper mapper, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var userId = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return NotFound<GetUserByIdResponse>("Invalide token");
            var user = userManager.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return NotFound<GetUserByIdResponse>("User not found");
            }
            //mapp
            var response = mapper.Map<GetUserByIdResponse>(user);
            return Success(response);
        }

        public async Task<PaginatedResult<GetUserPaginatedList>> Handle(GetUserPaginatedQuery request, CancellationToken cancellationToken)
        {
            var list = userManager.Users.AsQueryable();
            var paginateList = await mapper.ProjectTo<GetUserPaginatedList>(list)
                                     .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginateList;

        }

    }
}
