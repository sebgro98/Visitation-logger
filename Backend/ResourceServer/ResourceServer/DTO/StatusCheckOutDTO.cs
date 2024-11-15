namespace ResourceServer.DTO
{
    public class StatusCheckOutDTO
    {
        public DateTime CheckOutTime { get; set; }

        public string CheckOutSign { get; set; }

        public DateTime LastExportDate { get; set; }

        public bool IsExport { get; set; }

    }
}
