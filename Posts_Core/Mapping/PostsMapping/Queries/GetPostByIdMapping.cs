using Posts_Core.Features.Postss.Queries.Models;
using Posts_Data.Entities;

namespace Posts_Core.Mapping.PostsMapping
{
    public partial class PostProfile
    {
        public void GetPostByIdMapping()
        {
            CreateMap<Blog, GetAllPostsForUserQuery>();
        }
    }
}
