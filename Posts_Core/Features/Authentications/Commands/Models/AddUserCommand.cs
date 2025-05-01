using MediatR;
using Posts_Core.Bases;

namespace Posts_Core.Features.Authentications.Commands.Models
{
    public class AddUserCommand : IRequest<Response<string>>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
