using HotelGuide.Shared.Common;

namespace HotelService.Domain.Entities
{
    public class Maps : BaseEntity
    {
        public string Description { get; set; }
        public Guid CityId { get; set; }
        public Guid CountyId { get; set; }
        public Guid DistrictId { get; set; }
 
    }
}
