using ContainerManagement.Domain.Dtos;
using ContainerManagement.Service.Features.Commands;
using ContainerManagement.Service.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ContainerManagement.Controller
{
    [ApiController]
    [Route("api/v{version:apiVersion}/containers")]
    [ApiVersion("1.0")]
    public class ContainersController : ControllerBase
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
        public async Task<IActionResult> Create([FromBody] ContainerDto containerDto)
        {
            CreateContainerCommand command = new()
            {
                ContainerDto = containerDto
            };
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllContainersQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await Mediator.Send(new GetContainerByIdQuery { ContainerId = id }));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ContainerDto containerDto)
        {
            UpdateContainerCommand command = new()
            {
                ContainerDto = containerDto
            };
            if (command.ContainerDto.ContainerId == Guid.Empty)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteContainerByIdCommand { ContainerId = id }));
        }

    }
}
