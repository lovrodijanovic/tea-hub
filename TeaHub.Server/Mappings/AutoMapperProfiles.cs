using AutoMapper;
using TeaHub.Server.Models.Domain;
using TeaHub.Server.Models.DTO;

namespace TeaHub.Server.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TypeDTO, Models.Domain.Type>().ReverseMap();
            CreateMap<AddTypeRequestDTO, Models.Domain.Type>().ReverseMap();
            CreateMap<UpdateTypeRequestDTO, Models.Domain.Type>().ReverseMap();

            CreateMap<OriginDTO, Origin>().ReverseMap();
            CreateMap<AddOriginRequestDTO, Origin>().ReverseMap();
            CreateMap<UpdateOriginRequestDTO, Origin>().ReverseMap();

            CreateMap<TeaDTO, Tea>().ReverseMap();
            CreateMap<AddTeaRequestDTO, Tea>().ReverseMap();
            CreateMap<UpdateTeaRequestDTO, Tea>().ReverseMap();
        }
    }
}
