using AutoMapper;
using ContainerManagement.Domain.Dtos;
using ContainerManagement.Domain.Entities;

namespace ContainerManagement.Infrastructure.Mappings
{
    public class ContainerProfile : Profile
    {
        public ContainerProfile()
        {
            CreateMap<ContainerDto, Container>()
                .ForMember(dest => dest.ContainerType, opt =>
                  opt.Ignore());
        }
    }
}
