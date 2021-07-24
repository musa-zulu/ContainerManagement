using ContainerManagement.Service.Contract;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContainerManagement.Service.Features.ContainerTypeFeatures.Commands
{
    public class DeleteContainerTypesByIdCommand : IRequest<bool>
    {
        public Guid ContainerTypeId { get; set; }
        public class DeleteContainerTypesByIdCommandHandler : IRequestHandler<DeleteContainerTypesByIdCommand, bool>
        {
            private readonly IContainerTypeService _containerTypeService;
            public DeleteContainerTypesByIdCommandHandler(IContainerTypeService containerTypeService)
            {
                _containerTypeService = containerTypeService ?? throw new ArgumentNullException(nameof(containerTypeService));
            }
            public async Task<bool> Handle(DeleteContainerTypesByIdCommand request, CancellationToken cancellationToken)
            {
                var results = await _containerTypeService.DeleteContainerTypeAsync(request.ContainerTypeId);
                return results;
            }
        }
    }
}