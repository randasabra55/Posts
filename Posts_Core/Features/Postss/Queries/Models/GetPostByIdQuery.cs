using MediatR;
using Posts_Core.Bases;
using Posts_Core.Features.Postss.Queries.Results;

namespace Posts_Core.Features.Postss.Queries.Models
{
    public class GetPostByIdQuery : IRequest<Response<GetPostsForUserResult>>
    {
        public int postId { get; set; }
        public GetPostByIdQuery(int postId)
        {
            this.postId = postId;
        }
    }
}
