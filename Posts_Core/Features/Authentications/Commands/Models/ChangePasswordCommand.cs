using MediatR;
using Posts_Core.Bases;

namespace Posts_Core.Features.Authentications.Commands.Models
{
    public class ChangePasswordCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }
        public string OldPass { get; set; }
        public string NewPass { get; set; }
    }
}
