using MediatR;
using Posts_Core.Bases;

namespace Posts_Core.Features.Postss.Commands.Models
{
    public class EditPostCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
