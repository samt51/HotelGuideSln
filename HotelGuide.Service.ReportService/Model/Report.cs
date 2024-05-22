using HotelGuide.Shared.Common;
using HotelGuide.Shared.Enums;

namespace HotelGuide.Service.ReportService.Model
{
    public class Report : BaseEntity
    {
        public DateTime DateRequested { get; private set; }
        public ReportStatusEnum ReportStatus { get; set; }

    }
}
