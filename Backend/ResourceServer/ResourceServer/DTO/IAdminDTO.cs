namespace ResourceServer.DTO
{
    public interface IAdminDTO
    {      
        public string Username { get; set; }
     
        public string Password { get; set; }

        public Guid AccountTypeId { get; set; }

        public Guid NodeId { get; set; }

        public string FullName { get; set; }
    }
}
