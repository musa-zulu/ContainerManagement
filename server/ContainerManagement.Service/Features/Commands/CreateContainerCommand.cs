using AutoMapper;
using ContainerManagement.Domain.Dtos;
using ContainerManagement.Domain.Entities;
using ContainerManagement.Service.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContainerManagement.Service.Features.Commands
{
    public class CreateContainerCommand : IRequest<bool>
    {
        public ContainerDto ContainerDto { get; set; }

        public class CreateContainerCommandHandler : IRequestHandler<CreateContainerCommand, bool>
        {
            private readonly IContainerService _containerService;
            private readonly IMapper _mapper;
            public CreateContainerCommandHandler(IContainerService containerService, IMapper mapper)
            {
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _containerService = containerService ?? throw new ArgumentNullException(nameof(containerService));
            }
            public async Task<bool> Handle(CreateContainerCommand request, CancellationToken cancellationToken)
            {
                var container = _mapper.Map<Containers>(request.ContainerDto);
                container.ContainerId = Guid.NewGuid();
                var containerSaved = false;
                if (container != null)
                {
                    containerSaved = await _containerService.CreateContainerAsync(container);
                }
                return containerSaved;
            }
        }
    }
}