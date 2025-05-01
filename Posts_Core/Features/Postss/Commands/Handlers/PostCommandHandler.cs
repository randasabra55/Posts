using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Posts_Core.Bases;
using Posts_Core.Features.Postss.Commands.Models;
using Posts_Data.Entities;
using Posts_Data.Entities.Identity;
using Posts_Services.Abstracts;

namespace Posts_Core.Features.Postss.Commands.Handlers
{
    public class PostCommandHandler : ResponseHandler,
                                    IRequestHandler<AddPostCommand, Response<string>>,
                                    IRequestHandler<EditPostCommand, Response<string>>,
                                    IRequestHandler<DeletePostCommand, Response<string>>
    {
        IMapper mapper;
        IPostService postService;
        UserManager<User> userManager;
        public PostCommandHandler(IPostService postService, IMapper mapper, UserManager<User> userManager)
        {
            this.postService = postService;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        public async Task<Response<string>> Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.userId);
            if (user == null)
                return NotFound<string>($"User not found with id {request.userId}");
            var postMapper = mapper.Map<Blog>(request);
            var result = await postService.AddPostAsync(postMapper);
            if (result == "Success")
                return Success("Post added successfully");
            return BadRequest<string>("can not add post, try again");
        }

        public async Task<Response<string>> Handle(EditPostCommand request, CancellationToken cancellationToken)
        {
            var post = await postService.GetPostByIdAsync(request.Id);
            if (post == null)
                return NotFound<string>($"this post with id {request.Id} no found to edit it");
            var updatedPost = mapper.Map(request, post);
            var result = await postService.EditPostAsync(post);
            if (result == "Success")
                return Success("Post updated successfully");
            return BadRequest<string>("can not update post, try again");
        }

        public async Task<Response<string>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await postService.GetPostByIdAsync(request.Id);
            if (post == null)
                return NotFound<string>($"this post with id {request.Id} no found to delete it");
            var result = await postService.DeletePostAsync(request.Id);
            if (result == "Success")
                return Success("Post deleted successfully");
            return BadRequest<string>("can not delete post, try again");
        }
    }
}
