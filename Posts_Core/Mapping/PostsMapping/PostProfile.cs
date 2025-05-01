using AutoMapper;

namespace Posts_Core.Mapping.PostsMapping
{
    public partial class PostProfile : Profile
    {
        public PostProfile()
        {
            AddPostMapping();
            EditPostMapping();
            GetPostByIdMapping();
            GetPostsForUserMapping();
            GetAllPostsMapping();
        }
    }
}
