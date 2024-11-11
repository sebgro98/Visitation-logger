namespace ResourceServer.DTO
{
    public class AdminPostDTO
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public Guid AdminTypeId { get; set; }
    }
}
