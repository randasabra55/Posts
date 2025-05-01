using MediatR;
using Posts_Core.Bases;

namespace Posts_Core.Features.Authentications.Commands.Models
{
    public class EditUserCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
    }
}
