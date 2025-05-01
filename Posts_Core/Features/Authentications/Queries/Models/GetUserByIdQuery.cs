using MediatR;
using Posts_Core.Bases;
using Posts_Core.Features.Authentications.Queries.Results;

namespace Posts_Core.Features.Authentications.Queries.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {

    }
}
