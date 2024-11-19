namespace ResourceServer.DTO
{
    public class FilterDTO
    {
        public Guid? NodeId { get; set; }
        public string? CheckInTime { get; set; } //Format yyyy-MM-dd
        public string? CheckOutTime { get; set; } //Format yyyy-MM-dd
        public string? CheckInSign { get; set; }
        public string? CheckOutSign { get; set; }
    }
}
