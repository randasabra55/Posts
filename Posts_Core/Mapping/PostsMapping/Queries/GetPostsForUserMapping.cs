using Posts_Core.Features.Postss.Queries.Results;
using Posts_Data.Entities;

namespace Posts_Core.Mapping.PostsMapping
{
    public partial class PostProfile
    {
        public void GetPostsForUserMapping()
        {
            CreateMap<Blog, GetPostsForUserResult>();
        }
    }
}
