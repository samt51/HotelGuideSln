using AutoMapper;
using ContactInformationService.Application.Features.ContactInformation.Dtos;

namespace HotelService.Persistence.Concrete.MappingTo
{
    public class HotelServiceMapping : Profile
    {
        public HotelServiceMapping()
        {
            //CreateMap<List<HotelService.Domain.Entities.ContactInformation>, List<CreatedContactInformationDto>>();
            //CreateMap<HotelService.Domain.Entities.ContactInformation>, CreatedContactInformationDto>();
        }
    }
}
