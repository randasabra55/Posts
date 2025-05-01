using Posts_Data.Entities;
using Posts_Infrastructure.Abstracts;
using Posts_Services.Abstracts;

namespace Posts_Services.Implementations
{
    public class PostService : IPostService
    {
        IPostRepository postRepository;
        public PostService(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        public async Task<string> AddPostAsync(Blog post)
        {
            await postRepository.AddAsync(post);
            return "Success";
        }

        public async Task<string> DeletePostAsync(int id)
        {
            var post = await postRepository.GetByIdAsync(id);
            if (post == null)
                return "NotFound";
            await postRepository.DeleteAsync(post);
            return "Success";
        }

        public async Task<string> EditPostAsync(Blog post)
        {
            await postRepository.UpdateAsync(post);
            return "Success";
        }

        public IQueryable<Blog> GetAllPosts()
        {
            return postRepository.getAllPostsQuerable();
        }

        public IQueryable<Blog> GetAllPostsForUser(string userId)
        {
            return postRepository.getPostsForUserQuerable(userId);
        }

        public async Task<Blog> GetPostByIdAsync(int id)
        {
            return await postRepository.GetByIdAsync(id);
        }
    }
}
