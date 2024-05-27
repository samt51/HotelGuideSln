using HotelGuide.Shared.Common;
using HotelGuide.Shared.Enums;

namespace ReportService.Domain.Entities
{
    public class Report : BaseEntity
    {
        public DateTime DateRequested { get;  set; }
        public ReportStatusEnum ReportStatus { get; set; }
    }
}
