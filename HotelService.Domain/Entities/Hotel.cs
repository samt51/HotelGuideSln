using HotelGuide.Shared.Common;

namespace HotelService.Domain.Entities
{
    public class Hotel : BaseEntity
    {
        public Hotel()
        {

        }
        public Hotel(Guid id, string authorizedName, string authorizedSurName, string companyName)
        {

            this.Id = id;
            this.AuthorizedName = authorizedName;
            this.AuthorizedSurName = authorizedSurName;
            this.CompanyName = companyName;
        }
        public string AuthorizedName { get; set; }
        public string AuthorizedSurName { get; set; }
        public string CompanyName { get; set; }

    }
}
