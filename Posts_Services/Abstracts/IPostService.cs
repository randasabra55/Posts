using Posts_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posts_Services.Abstracts
{
    public interface IPostService
    {
        public Task<string> AddPostAsync(Blog post);
        public Task<string> EditPostAsync(Blog post);
        public Task<string> DeletePostAsync(int id);
        public Task<Blog> GetPostByIdAsync(int id);
        public IQueryable<Blog> GetAllPosts();
        public IQueryable<Blog> GetAllPostsForUser(string userId);

    }
}
