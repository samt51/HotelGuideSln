using HotelGuide.Shared.Common;
using HotelGuide.Shared.Enums;

namespace ContactInformationService.Domain.Entities;

public class ContactInformation : BaseEntity
{
    public ContactInformation()
    {
        
    }
    public ContactInformation(InformationTypeEnum informationTypeEnum, string informationContent, Guid hotelId, Guid id)
    {
        this.Id = id;
        this.InformationType = informationTypeEnum;
        this.InformationContent = informationContent;
        this.HotelId = hotelId;
    }
    public InformationTypeEnum InformationType { get; set; }
    public string InformationContent { get; set; }
    public Guid HotelId { get; set; }
}
