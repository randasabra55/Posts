using Posts_Core.Features.Authentications.Queries.Results;
using Posts_Data.Entities.Identity;

namespace Posts_Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void GetUserById()
        {
            CreateMap<User, GetUserByIdResponse>();
        }
    }
}
