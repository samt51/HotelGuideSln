using HotelGuide.Shared.Enums;

namespace HotelGuide.Shared.MessageQuery.Events
{
    public class HotelCreatedEvent
    {
        public InformationTypeEnum InformationType { get; set; }
        public string InformationContent { get; set; }
        public Guid HotelId { get; set; }
    }
}
