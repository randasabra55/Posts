
using Posts_Data.Entities.Identity;
using Posts_Data.Results;

namespace Posts_Service.Abstracts
{
    public interface IAuthenticationService
    {
        public Task<string> Register(User user, string password);
        public Task<JwtAuthResult> GetJWTToken(User user);

    }
}
