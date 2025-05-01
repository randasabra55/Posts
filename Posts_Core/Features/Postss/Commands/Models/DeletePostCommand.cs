using MediatR;
using Posts_Core.Bases;

namespace Posts_Core.Features.Postss.Commands.Models
{
    public class DeletePostCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeletePostCommand(int id)
        {
            Id = id;
        }
    }
}
