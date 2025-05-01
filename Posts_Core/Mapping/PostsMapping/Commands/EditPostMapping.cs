using Posts_Core.Features.Postss.Commands.Models;
using Posts_Data.Entities;

namespace Posts_Core.Mapping.PostsMapping
{
    public partial class PostProfile
    {
        public void EditPostMapping()
        {
            CreateMap<EditPostCommand, Blog>();
        }
    }
}
