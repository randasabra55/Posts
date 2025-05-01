using Posts_Core.Features.Postss.Queries.Results;
using Posts_Data.Entities;

namespace Posts_Core.Mapping.PostsMapping
{
    public partial class PostProfile
    {
        public void GetAllPostsMapping()
        {
            CreateMap<Blog, GetAllPostsResult>()
                .ForMember(des => des.FullName, opt => opt.MapFrom(src => src.User.FullName));
        }
    }
}
