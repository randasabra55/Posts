using Posts_Core.Features.Authentications.Commands.Models;
using Posts_Data.Entities.Identity;

namespace Posts_Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void EditUserMapping()
        {
            CreateMap<EditUserCommand, User>();
        }
    }
}
