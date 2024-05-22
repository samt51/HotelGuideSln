using HotelGuide.Shared.Common;
using HotelGuide.Shared.Enums;

namespace HotelGuide.Service.ContactInformationService.Model;

public class ContactInformation : BaseEntity
{
    public ContactInformation(InformationTypeEnum informationTypeEnum, string informationContent, Guid hotelId, Guid id)
    {
        this.Id = id;
        this.InformationType = informationTypeEnum;
        this.InformationContent = informationContent;
        this.HotelId = hotelId;
    }
    public InformationTypeEnum InformationType { get; private set; }
    public string InformationContent { get; private set; }
    public Guid HotelId { get; private set; }
}
