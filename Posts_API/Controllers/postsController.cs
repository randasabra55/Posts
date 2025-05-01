using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Posts_API.Bases;
using Posts_Core.Features.Postss.Commands.Models;
using Posts_Core.Features.Postss.Queries.Models;

namespace Posts_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class postsController : AppControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddPostAsync(AddPostCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        /////////////////////////////////////////////////////
        [HttpPut]
        public async Task<IActionResult> EditPostAsync(EditPostCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        /////////////////////////////////////////////////////////
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostByIdAsync(int id)
        {
            var response = await Mediator.Send(new DeletePostCommand(id));
            return NewResult(response);
        }
        /////////////////////////////////////////////////////////
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostByIdAsync(int id)
        {
            var response = await Mediator.Send(new GetPostByIdQuery(id));
            return NewResult(response);
        }
        //////////////////////////////////////////////////////////
        [HttpGet("me")]
        public async Task<IActionResult> GetPostForUserId([FromQuery] GetAllPostsForUserQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        ////////////////////////////////////////////////////////////////
        [HttpGet("All")]
        public async Task<IActionResult> GetAllPosts([FromQuery] GetAllPostsQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
    }
}
