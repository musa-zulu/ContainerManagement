using ContainerManagement.Domain.Dtos;
using ContainerManagement.Service.Features.ContainerTypeFeatures.Commands;
using ContainerManagement.Service.Features.ContainerTypeFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ContainerManagement.Controller
{
    [ApiController]
    [Route("api/v{version:apiVersion}/container-types")]
    [ApiVersion("1.0")]
    public class ContainerTypeController : ControllerBase
    {
        private IMediator _mediator;
        public IMediator Mediator
        {
            get { return _mediator ??= HttpContext.RequestServices.GetService<IMediator>(); }
            set
            {
                if (_mediator != null) throw new InvalidOperationException("Mediator is already set");
                _mediator = value;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContainerTypeDto containerTypeDto)
        {
            CreateContainerTypeCommand command = new()
            {
                ContainerTypeDto = containerTypeDto
            };
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllContainerTypeQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await Mediator.Send(new GetContainerTypeByIdQuery { ContainerTypeId = id }));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ContainerTypeDto containerTypeDto)
        {
            UpdateContainerTypeCommand command = new()
            {
                ContainerTypeDto = containerTypeDto
            };
            if (command.ContainerTypeDto.ContainerTypeId == Guid.Empty)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteContainerTypesByIdCommand { ContainerTypeId = id }));
        }
    }
}