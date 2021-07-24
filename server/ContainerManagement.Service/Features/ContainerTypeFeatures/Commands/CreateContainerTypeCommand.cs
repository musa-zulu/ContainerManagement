using AutoMapper;
using ContainerManagement.Domain.Dtos;
using ContainerManagement.Service.Contract;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContainerManagement.Service.Features.ContainerTypeFeatures.Commands
{
    public class CreateContainerTypeCommand : IRequest<bool>
    {
        public ContainerTypeDto ContainerTypeDto { get; set; }

        public class CreateContainerTypeCommandHandler : IRequestHandler<CreateContainerTypeCommand, bool>
        {
            private readonly IContainerTypeService _containerTypeService;
            private readonly IMapper _mapper;
            public CreateContainerTypeCommandHandler(IContainerTypeService containerTypeService, IMapper mapper)
            {
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _containerTypeService = containerTypeService ?? throw new ArgumentNullException(nameof(containerTypeService));
            }
            public async Task<bool> Handle(CreateContainerTypeCommand request, CancellationToken cancellationToken)
            {
                var containerType = _mapper.Map<Domain.Entities.ContainerType>(request.ContainerTypeDto);
                containerType.ContainerTypeId = Guid.NewGuid();
                var containerSaved = false;
                if (containerType != null)
                {
                    containerSaved = await _containerTypeService.CreateContainerTypeAsync(containerType);
                }
                return containerSaved;
            }
        }
    }
}