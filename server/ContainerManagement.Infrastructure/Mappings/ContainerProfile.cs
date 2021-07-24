using AutoMapper;
using ContainerManagement.Domain.Dtos;
using ContainerManagement.Domain.Entities;

namespace ContainerManagement.Infrastructure.Mappings
{
    public class ContainerProfile : Profile
    {
        public ContainerProfile()
        {
            CreateMap<ContainerDto, Containers>().ReverseMap();
        }
    }
}
