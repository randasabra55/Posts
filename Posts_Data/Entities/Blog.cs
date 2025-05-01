using Posts_Data.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Posts_Data.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        [ForeignKey("User")]
        public string userId { get; set; }
        public virtual User User { get; set; }
    }
}
