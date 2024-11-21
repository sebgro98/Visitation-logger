using SharedModels.Models;

namespace ResourceServer.DTO
{
    public class StatusDTO
    {
        public Guid Id { get; set; }

        public Guid VisitorId { get; set; }

        public string VisitorName { get; set; }

        public DateTime CheckInTime { get; set; }

        public DateTime? CheckOutTime { get; set; }

        public Node Node { get; set; }

        public string PurposeName { get; set; }

        public StatusDTO(Status status)
        {
            Id = status.Id;
            var Visitor = status.VisitorAccount.Visitor;
            VisitorId = Visitor.Id;
            VisitorName = Visitor.FullName;
            CheckInTime = status.CheckInTime;
            CheckOutTime = status.CheckOutTime;
            Node = status.Node;
            PurposeName = status.VisitorAccount.PurposeType.Name;
        }
    }
}
