using ContainerManagement.Domain.Entities;
using ContainerManagement.Service.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContainerManagement.Service.Features.ContainerFeatures.Queries
{
    public class GetAllContainersQuery : IRequest<IEnumerable<Container>>
    {
        public class GetAllContainersQueryHandler : IRequestHandler<GetAllContainersQuery, IEnumerable<Container>>
        {
            private readonly IContainerService _containerService;
            public GetAllContainersQueryHandler(IContainerService containerService)
            {
                _containerService = containerService ?? throw new ArgumentNullException(nameof(containerService));
            }
            public async Task<IEnumerable<Container>> Handle(GetAllContainersQuery request, CancellationToken cancellationToken)
            {
                var containers = await _containerService.GetContainersAsync();
                if (containers == null)
                {
                    return null;
                }
                return containers.AsReadOnly();
            }
        }
    }
}
