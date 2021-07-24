using ContainerManagement.Service.Contract;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContainerManagement.Service.Features.Commands
{
    public class DeleteContainerByIdCommand : IRequest<bool>
    {
        public Guid ContainerId { get; set; }
        public class DeleteContainerByIdCommandHandler : IRequestHandler<DeleteContainerByIdCommand, bool>
        {
            private readonly IContainerService _containerService;
            public DeleteContainerByIdCommandHandler(IContainerService containerService)
            {
                _containerService = containerService ?? throw new ArgumentNullException(nameof(containerService));
            }
            public async Task<bool> Handle(DeleteContainerByIdCommand request, CancellationToken cancellationToken)
            {
                var results = await _containerService.DeleteContainerAsync(request.ContainerId);
                return results;
            }
        }
    }
}