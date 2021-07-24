using ContainerManagement.Domain.Entities;
using ContainerManagement.Service.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContainerManagement.Service.Features.Queries
{
    public class GetAllContainersQuery : IRequest<IEnumerable<Containers>>
    {
        public class GetAllContainersQueryHandler : IRequestHandler<GetAllContainersQuery, IEnumerable<Containers>>
        {
            private readonly IContainerService _containerService;
            public GetAllContainersQueryHandler(IContainerService containerService)
            {
                _containerService = containerService ?? throw new ArgumentNullException(nameof(containerService));
            }
            public async Task<IEnumerable<Containers>> Handle(GetAllContainersQuery request, CancellationToken cancellationToken)
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
