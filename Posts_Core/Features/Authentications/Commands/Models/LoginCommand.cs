using MediatR;
using Posts_Core.Bases;
using Posts_Data.Results;

namespace Posts_Core.Features.Authentications.Commands.Models
{
    public class LoginCommand : IRequest<Response<JwtAuthResult>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
