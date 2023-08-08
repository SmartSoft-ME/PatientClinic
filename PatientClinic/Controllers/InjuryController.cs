using Microsoft.AspNetCore.Mvc;
using Application.Commands.InjuryCommands;
using Application.DTO;
using Application.Queries.InjuryQueries;
using Domain;
using MediatR;
using Shared;
using FluentValidation.AspNetCore;
using FluentValidation;

namespace PatientClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InjuryController : ControllerBase
    {
        private readonly IValidator<Injury> _validator;
        private readonly IMediator _mediator;
        public InjuryController(IMediator mediator, IValidator<Injury> validator)
        {
            _validator = validator;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<List<InjuryDto>> Get([FromQuery] GetAllInjuryQuery query, CancellationToken cancel)
        {
            return await _mediator.Send(query, cancel);
            
            
        }
        [HttpGet("Get By Id")]
        public async Task<InjuryDto> GetById([FromQuery] GetInjuryByIdQuery query,CancellationToken cancel)
            => await _mediator.Send(query,cancel);
        [HttpDelete]
        public async Task delete(DeleteInjuryCommand command,CancellationToken cancel)
            => await _mediator.Send(command,cancel);
        [HttpPost]
        public async Task<Response<InjuryDto>> Create(CreateInjuryCommand command, CancellationToken cancel)
            => await _mediator.Send(command, cancel);
        [HttpPut]
        public async Task<Response<InjuryDto>> Update(UpdateInjuryCommand command, CancellationToken cancel)
            => await _mediator.Send(command, cancel);
    }
}
