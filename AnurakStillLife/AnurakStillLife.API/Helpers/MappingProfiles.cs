using AnurakStillLife.API.Dtos;
using AutoMapper;
using Core;

namespace AnurakStillLife.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ArtWork, ArtWorkDto>()
                .ForMember(d => d.ArtType, o => o.MapFrom(s => s.ArtType.TypeName))
                .ForMember(d => d.Artist, o => o.MapFrom(s => s.Artist.FirstName));
        }
    }
}
