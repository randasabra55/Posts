using MediatR;
using Posts_Core.Bases;

namespace Posts_Core.Features.Authentications.Commands.Models
{
    public class DeleteUserByTokenCommand : IRequest<Response<string>>
    {
    }
}
