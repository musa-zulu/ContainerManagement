using ContainerManagement.Domain.Entities;
using ContainerManagement.Service.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContainerManagement.Service.Features.ContainerTypeFeatures.Queries
{
    public class GetAllContainerTypeQuery : IRequest<IEnumerable<ContainerType>>
    {
        public class GetAllContainerTypeQueryHandler : IRequestHandler<GetAllContainerTypeQuery, IEnumerable<ContainerType>>
        {
            private readonly IContainerTypeService _containerTypeService;
            public GetAllContainerTypeQueryHandler(IContainerTypeService containerTypeService)
            {
                _containerTypeService = containerTypeService ?? throw new ArgumentNullException(nameof(containerTypeService));
            }
            public async Task<IEnumerable<ContainerType>> Handle(GetAllContainerTypeQuery request, CancellationToken cancellationToken)
            {
                var containerTypes = await _containerTypeService.GetContainerTypesAsync();
                if (containerTypes == null)
                {
                    return null;
                }
                return containerTypes.AsReadOnly();
            }
        }
    }
}
