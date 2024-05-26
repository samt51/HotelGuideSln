using AutoMapper;
using ContactInformationService.Application.Features.ContactInformation.Dtos;

namespace HotelService.Persistence.Concrete.MappingTo
{
    public class HotelServiceMapping : Profile
    {
        public HotelServiceMapping()
        {
            //CreateMap<IList<HotelService.Domain.Entities.ContactInformation>, IList<CreatedContactInformationDto>>();
            //CreateMap<HotelService.Domain.Entities.ContactInformation>, CreatedContactInformationDto>();
        }
    }
}
