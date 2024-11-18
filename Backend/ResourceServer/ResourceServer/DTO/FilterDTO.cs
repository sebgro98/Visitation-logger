namespace ResourceServer.DTO
{
    public class FilterDTO
    {
        public Guid? NodeId { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public string? CheckInSign { get; set; }
        public string? CheckOutSign { get; set; }
        // public DateTime? LastExportDate { get; set; }
    }
}
