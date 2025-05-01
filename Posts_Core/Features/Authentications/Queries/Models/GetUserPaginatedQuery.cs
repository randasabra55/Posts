using MediatR;
using Posts_Core.Features.Authentications.Queries.Results;
using Posts_Core.Wrapper;

namespace Posts_Core.Features.Authentications.Queries.Models
{
    public class GetUserPaginatedQuery : IRequest<PaginatedResult<GetUserPaginatedList>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
