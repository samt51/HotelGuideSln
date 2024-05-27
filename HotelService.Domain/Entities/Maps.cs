using HotelGuide.Shared.Common;

namespace HotelService.Domain.Entities
{
    public class Maps : BaseEntity
    {
        public Maps()
        {
            
        }
        public Maps(Guid id, string description, Guid cityId, Guid countryId, Guid districtId)
        {
            this.Id = id;
            this.Description = description;
            this.CityId = cityId;
            this.CountyId = countryId;
            this.DistrictId = districtId;
        }
        public string Description { get; set; }
        public Guid CityId { get; set; }
        public Guid CountyId { get; set; }
        public Guid DistrictId { get; set; }

    }
}
