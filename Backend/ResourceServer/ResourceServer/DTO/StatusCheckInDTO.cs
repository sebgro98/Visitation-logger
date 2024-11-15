namespace ResourceServer.DTO
{
    public class StatusCheckInDTO
    {
        public Guid VisitorId { get; set; }

        public DateTime CheckInTime { get; set; }

        public string CheckInSign { get; set; }

        public Guid NodeId { get; set; }

    }
}
