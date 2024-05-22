using HotelGuide.Shared.Common;

namespace HotelGuide.Service.Hotel.Model
{
    public class Hotel : BaseEntity
    {
        public string AuthorizedName { get; private set; }
        public string AuthorizedSurName { get; private set; }
        public string CompanyName { get; private set; }

    }
}
