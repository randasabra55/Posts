using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Posts_API.Bases;
using Posts_Core.Features.Authentications.Commands.Models;
using Posts_Core.Features.Authentications.Queries.Models;


namespace Posts_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : AppControllerBase
    {

        [HttpPost("Register")]
        //[HttpPost]
        public async Task<IActionResult> RegisterAsync(AddUserCommand addUser)
        {

            var result = await Mediator.Send(addUser);
            return NewResult(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [Authorize]
        [HttpPut("me/password")]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }



        [Authorize]
        // [HttpPut("EditProfile")]
        [HttpPut("me")]
        public async Task<IActionResult> EditUserAsync(EditUserCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }



        [Authorize(Roles = "Admin")]
        [HttpDelete("me")]
        public async Task<IActionResult> DeleteUserByTokenAsync()
        {
            var result = await Mediator.Send(new DeleteUserByTokenCommand());
            return NewResult(result);
        }

        [Authorize(Roles = "Admin,User")]
        //[HttpGet("GetUserByToken")]
        [HttpGet("me")]
        public async Task<IActionResult> GetUserByIdAsync()
        {
            var result = await Mediator.Send(new GetUserByIdQuery());
            return NewResult(result);
        }

        [Authorize(Roles = "Admin,User")]
        //[HttpGet("Paginated")]
        [HttpGet]
        public async Task<IActionResult> GetUserPaginatedListAsync([FromQuery] GetUserPaginatedQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
