using HotelGuide.Shared.Common;
using HotelGuide.Shared.Enums;

namespace HotelService.Domain.Entities;

public class ContactInformation : BaseEntity
{
    public ContactInformation()
    {

    }
    public ContactInformation(InformationTypeEnum informationTypeEnum, string informationContent, Guid hotelId, Guid id)
    {
        this.Id = id;
        this.InformationType = informationTypeEnum;
        this.InformationContentValue = informationContent;
        this.HotelId = hotelId;
    }
    public InformationTypeEnum InformationType { get; set; }
    public string InformationContentValue { get; set; }
    public Guid HotelId { get; set; }
    public Hotel Hotel { get; set; }
}
