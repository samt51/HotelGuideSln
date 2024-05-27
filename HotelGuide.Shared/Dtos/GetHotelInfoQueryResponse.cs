using HotelGuide.Shared.Enums;

namespace HotelGuide.Shared.Dtos
{
    public class ReportType
    {
        public Guid ReportStatusId { get; set; }
        public ReportStatusEnum ReportStatusEnum { get; set; }
        public List<GetHotelInfoQueryResponse>  getHotelInfoQueryResponses { get; set; }

    }
    public class GetHotelInfoQueryResponse
    {
        public Guid MapId { get; set; }
        public string City { get; set; } = "Muğla";
        public string District { get; set; } = "Fethiye";
        public string Neighborhood { get; set; } = "Ölüdeniz";
        public int TotalHotelCount { get; set; }
        public int TotalHotelPhoneNumberCount { get; set; }
    }
}
