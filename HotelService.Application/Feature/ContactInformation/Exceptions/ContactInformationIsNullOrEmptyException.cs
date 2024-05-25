using HotelGuide.Shared.Bases;

namespace HotelService.Application.Feature.ContactInformation.Exceptions
{
    public class ContactInformationIsNullOrEmptyException : BaseException
    {
        public ContactInformationIsNullOrEmptyException() : base("Hotelin İletişim Bilgileri Mevcut Değildir.Öncelikle Eklemeniz Gerekmektedir.") { }

    }
}
