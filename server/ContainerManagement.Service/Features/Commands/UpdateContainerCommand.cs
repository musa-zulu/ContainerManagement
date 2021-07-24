using AutoMapper;
using ContainerManagement.Domain.Dtos;
using ContainerManagement.Domain.Entities;
using ContainerManagement.Service.Contract;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContainerManagement.Service.Features.Commands
{
    public class UpdateContainerCommand : IRequest<bool>
    {
        public ContainerDto ContainerDto { get; set; }

        public class UpdateContainerCommandHandler : IRequestHandler<UpdateContainerCommand, bool>
        {
            private readonly IContainerService _containerService;
            private readonly IMapper _mapper;
            public UpdateContainerCommandHandler(IContainerService containerService, IMapper mapper)
            {
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _containerService = containerService ?? throw new ArgumentNullException(nameof(containerService));
            }
            public async Task<bool> Handle(UpdateContainerCommand request, CancellationToken cancellationToken)
            {
                var container = _mapper.Map<Containers>(request.ContainerDto);
                var isSaved = false;
                if (container != null)
                {
                    isSaved = await _containerService.UpdateContainerAsync(container);
                }
                return isSaved;
            }
        }
    }
}