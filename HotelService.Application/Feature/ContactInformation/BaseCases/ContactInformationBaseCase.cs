using HotelGuide.Shared.Bases;
using HotelService.Application.Feature.ContactInformation.Exceptions;

namespace HotelService.Application.Feature.ContactInformation.BaseCases
{
    public class ContactInformationBaseCase : BaseRules
    {
        public Task ContactInformationIsNullOrEmpty(IList<HotelService.Domain.Entities.ContactInformation> contactInformation)
        {
            if (contactInformation.Count == 0 || contactInformation is null) throw new ContactInformationIsNullOrEmptyException();
            return Task.CompletedTask;
        }
    }
}
