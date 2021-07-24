using ContainerManagement.Domain.Entities;
using ContainerManagement.Service.Contract;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContainerManagement.Service.Features.ContainerTypeFeatures.Queries
{
    public class GetContainerTypeByIdQuery : IRequest<ContainerType>
    {
        public Guid ContainerTypeId { get; set; }
        public class GetContainerTypeByIdQueryHandler : IRequestHandler<GetContainerTypeByIdQuery, ContainerType>
        {
            private readonly IContainerTypeService _containerTypeService;
            public GetContainerTypeByIdQueryHandler(IContainerTypeService containerTypeService)
            {
                _containerTypeService = containerTypeService ?? throw new ArgumentNullException(nameof(containerTypeService));
            }
            public async Task<ContainerType> Handle(GetContainerTypeByIdQuery request, CancellationToken cancellationToken)
            {
                var containerType = _containerTypeService.GetContainerTypeByIdAsync(request.ContainerTypeId);
                if (containerType == null) return null;
                return await containerType;
            }
        }
    }
}
