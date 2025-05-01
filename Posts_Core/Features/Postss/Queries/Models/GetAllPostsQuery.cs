using MediatR;
using Posts_Core.Features.Postss.Queries.Results;
using Posts_Core.Wrapper;

namespace Posts_Core.Features.Postss.Queries.Models
{
    public class GetAllPostsQuery : IRequest<PaginatedResult<GetAllPostsResult>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
