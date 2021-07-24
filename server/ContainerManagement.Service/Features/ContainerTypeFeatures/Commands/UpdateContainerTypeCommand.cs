using AutoMapper;
using ContainerManagement.Domain.Dtos;
using ContainerManagement.Domain.Entities;
using ContainerManagement.Service.Contract;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContainerManagement.Service.Features.ContainerTypeFeatures.Commands
{
    public class UpdateContainerTypeCommand : IRequest<bool>
    {
        public ContainerTypeDto ContainerTypeDto { get; set; }

        public class UpdateContainerTypeCommandHandler : IRequestHandler<UpdateContainerTypeCommand, bool>
        {
            private readonly IContainerTypeService _containerTypeService;
            private readonly IMapper _mapper;
            public UpdateContainerTypeCommandHandler(IContainerTypeService containerTypeService, IMapper mapper)
            {
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _containerTypeService = containerTypeService ?? throw new ArgumentNullException(nameof(containerTypeService));
            }
            public async Task<bool> Handle(UpdateContainerTypeCommand request, CancellationToken cancellationToken)
            {
                var containerType = _mapper.Map<ContainerType>(request.ContainerTypeDto);
                var isSaved = false;
                if (containerType != null)
                {
                    isSaved = await _containerTypeService.UpdateContainerTypeAsync(containerType);
                }
                return isSaved;
            }
        }
    }
}