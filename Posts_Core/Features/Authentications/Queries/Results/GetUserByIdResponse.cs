namespace Posts_Core.Features.Authentications.Queries.Results
{
    public class GetUserByIdResponse
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
