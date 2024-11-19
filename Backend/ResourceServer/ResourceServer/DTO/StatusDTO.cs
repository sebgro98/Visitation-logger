namespace ResourceServer.DTO
{
    public class StatusDTO
    {
        public Guid VisitorId { get; set; }

        public DateTime CheckInTime { get; set; }

        public string CheckInSign { get; set; }
       
        public DateTime? CheckOutTime { get; set; }

        public string CheckOutSign { get; set; }
      
        public DateTime? LastExportDate { get; set; }

        public Guid NodeId { get; set; }

        public bool IsExport {  get; set; }
    }
}
