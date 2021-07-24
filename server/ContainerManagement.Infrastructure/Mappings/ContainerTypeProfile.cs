using AutoMapper;
using ContainerManagement.Domain.Dtos;
using ContainerManagement.Domain.Entities;

namespace ContainerManagement.Infrastructure.Mappings
{
    public class ContainerTypeProfile : Profile
    {
        public ContainerTypeProfile()
        {
            CreateMap<ContainerTypeDto, ContainerType>()
                .ForMember(dest => dest.Containers, opt =>
                    opt.Ignore());
        }
    }
}
