using MediatR;
using Posts_Core.Bases;

namespace Posts_Core.Features.Postss.Commands.Models
{
    public class AddPostCommand : IRequest<Response<string>>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string userId { get; set; }
    }
}
