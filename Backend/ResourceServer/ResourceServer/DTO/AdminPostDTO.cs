namespace ResourceServer.DTO
{
    public class AdminPostDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid AccountTypeId { get; set; }
    }
}
