using Posts_Data.Entities;
using Posts_Infrastructure.InfrastructureBases;

namespace Posts_Infrastructure.Abstracts
{
    public interface IPostRepository : IGenericRepository<Blog>
    {
        public IQueryable<Blog> getAllPostsQuerable();
        public IQueryable<Blog> getPostsForUserQuerable(string userId);

    }
}
