using HotelGuide.Shared.Common;

namespace HotelGuide.Service.ContactInformationService.Model
{
    public class Maps : BaseEntity
    {
        public string Name { get; set; }
        public Guid? CityId { get; set; }
        public Guid? DistrictId { get; set; }
    }
}
