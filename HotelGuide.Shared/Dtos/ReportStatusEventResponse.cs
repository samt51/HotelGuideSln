using HotelGuide.Shared.Enums;

namespace HotelGuide.Shared.Dtos
{
    public class ReportStatusEventResponse
    {
        public Guid Id { get; set; }
        public DateTime DateRequested { get; set; }
        public ReportStatusEnum ReportStatus { get; set; }
    }
}
