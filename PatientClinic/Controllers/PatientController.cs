using Microsoft.AspNetCore.Mvc;
using Application.Commands.InjuryCommands;
using Application.DTO;
using Application.Queries.InjuryQueries;
using Domain;
using MediatR;
using Shared;
using Application.Queries.PatientQueries;
using Application.Commands.PatientCommand;
using Application.Commands.PatientCommands;

namespace PatientClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<List<PatientDto>> Get([FromQuery] GetAllPatientQuerie query, CancellationToken cancel)
        => await _mediator.Send(query, cancel);
        [HttpGet("Get By Id")]
        public async Task<PatientDto> GetById([FromQuery] GetPatientByIdQueries query, CancellationToken cancel)
            => await _mediator.Send(query, cancel);
        [HttpDelete]
        public async Task delete(DeletePatientCommand command, CancellationToken cancel) => await _mediator.Send(command, cancel);
        [HttpPost]
        public async Task<Response<PatientDto>> Create(CreatePatientCommand command, CancellationToken cancel)
            => await _mediator.Send(command, cancel);
        [HttpPut]
        public async Task<Response<PatientDto>> Update(UpdatePatientCommand command, CancellationToken cancel)
            => await _mediator.Send(command, cancel);
    }
}
