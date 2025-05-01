namespace Posts_Core.Features.Postss.Queries.Results
{
    public class GetAllPostsResult
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FullName { get; set; }
    }
}
