namespace HotelService.Application.Feature.Hotels.Queries.GetHotelManagement
{
    public class GetHotelManagementQueryResponse
    {
        public Guid HotelId { get; set; }
        public string AuthorizedName { get; set; }
        public string AuthorizedSurName { get; set; }
    }
}
