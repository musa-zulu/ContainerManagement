using ContainerManagement.Domain.Entities;
using ContainerManagement.Service.Contract;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContainerManagement.Service.Features.Queries
{
    public class GetContainerByIdQuery : IRequest<Containers>
    {
        public Guid ContainerId { get; set; }
        public class GetContainerByIdQueryHandler : IRequestHandler<GetContainerByIdQuery, Containers>
        {
            private readonly IContainerService _containerService;
            public GetContainerByIdQueryHandler(IContainerService containerService)
            {
                _containerService = containerService ?? throw new ArgumentNullException(nameof(containerService));
            }
            public async Task<Containers> Handle(GetContainerByIdQuery request, CancellationToken cancellationToken)
            {
                var container = _containerService.GetContainerByIdAsync(request.ContainerId);
                if (container == null) return null;
                return await container;
            }
        }
    }
}
