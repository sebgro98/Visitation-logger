namespace ResourceServer.DTO
{
    public class FilterDTO
    {
        public string? VisitorName { get; set; }
        public string? VisitorId { get; set; }
        public string? PurposeName { get; set; }
        public string? NodeId { get; set; }
        public string? CheckInTime { get; set; } //Format yyyy-MM-dd
        public string? CheckOutTime { get; set; } //Format yyyy-MM-dd
        // public string? CheckInSign { get; set; }
        // public string? CheckOutSign { get; set; }
    }
}
