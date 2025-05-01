

//using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Posts_Data.Entities.Identity;
using Posts_Data.Helper;
using Posts_Data.Results;
using Posts_Infrastructure.Data;
using Posts_Service.Abstracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Posts_Service.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        UserManager<User> userManager;
        JwtSettings jwtSettings;
        Context context;
        public AuthenticationService(UserManager<User> userManager, JwtSettings jwtSettings, Context context)
        {
            this.userManager = userManager;
            this.jwtSettings = jwtSettings;
            this.context = context;
        }

        public async Task<JwtAuthResult> GetJWTToken(User user)
        {
            //design token
            var accessToken = new JwtSecurityToken(
                issuer: jwtSettings.issuer,
                audience: jwtSettings.audience,
                expires: DateTime.Now.AddDays(jwtSettings.AccessTokenExpireDate),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.secret)), SecurityAlgorithms.HmacSha256Signature),
                claims: await GetClaims(user)
                );
            RefreshToken refreshToken = new RefreshToken()
            {
                UserName = user.UserName,
                ExpireAt = DateTime.Now.AddDays(jwtSettings.RefreshTokenExpireDate),
                Token = GenerateRefreshToken(),
            };
            JwtAuthResult jwtAuthResult = new JwtAuthResult()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                refreshToken = refreshToken
            };
            return jwtAuthResult;

        }

        public async Task<List<Claim>> GetClaims(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };
            var Rules = await userManager.GetRolesAsync(user);
            foreach (var rule in Rules)
            {
                claims.Add(new Claim(ClaimTypes.Role, rule));
            }

            return claims;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            var genrator = RandomNumberGenerator.Create();
            genrator.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public async Task<string> Register(User user, string password)
        {

            //chek email exist or not
            var existEmail = await userManager.FindByEmailAsync(user.Email);
            if (existEmail != null)
            {
                return "EmailIsExist";
            }
            //check user name
            var existUserName = await userManager.FindByNameAsync(user.UserName);
            if (existUserName != null)
            {
                return "UserNameIsExist";
            }
            try
            {
                var result = await userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    return string.Join(",", result.Errors.Select(x => x.Description).ToList());
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.InnerException?.Message ?? ex.Message}";

            }


            //add him to role
            await userManager.AddToRoleAsync(user, "User");
            return "Created";

        }


    }

}

