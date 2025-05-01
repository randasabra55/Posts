using Microsoft.EntityFrameworkCore;
using Posts_Data.Entities;
using Posts_Infrastructure.Abstracts;
using Posts_Infrastructure.Data;
using Posts_Infrastructure.InfrastructureBases;

namespace Posts_Infrastructure.Implementations
{
    public class PostRepository : GenericRepository<Blog>, IPostRepository
    {
        private DbSet<Blog> posts;
        public PostRepository(Context dbContext) : base(dbContext)
        {
            posts = dbContext.Set<Blog>();
        }

        public IQueryable<Blog> getAllPostsQuerable()
        {
            return posts.AsNoTracking().Include(p => p.User).AsQueryable();
        }

        public IQueryable<Blog> getPostsForUserQuerable(string userId)
        {
            return posts.AsNoTracking().Where(p => p.userId == userId).AsQueryable();
        }
    }
}
