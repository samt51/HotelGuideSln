using HotelGuide.Shared.Enums;

namespace HotelGuide.Shared.MessageQuery.Events
{
    public class ReportStatusEvent
    {
        public Guid Id { get; set; }
        public DateTime DateRequested { get; set; }
        public ReportStatusEnum ReportStatus { get; set; }
    }
}
