using Application.Commands.InjuryCommands;
using Application.DTO;
using Application.IRepositories;
using MediatR;
using Shared.Commands;
using Shared;
using Mapster;
using Domain;
using Application.Commands.PatientCommands;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using FluentValidation;
using Microsoft.Extensions.Hosting;

namespace Application.Commands.PatientCommand.Handler
{
    internal class CreatePatientHandler:ICommandHandler<CreatePatientCommand,PatientDto>
    {
        
        private readonly IPatientRepository _patientRepository;
        private readonly   IInjuryRepository _injuryRepository;
        public CreatePatientHandler( IPatientRepository PRepository,IInjuryRepository injuryRepository)
        {
           
            _patientRepository = PRepository;
            _injuryRepository=injuryRepository;
        }
        public async Task<Response<PatientDto>> Handle(CreatePatientCommand request,CancellationToken cancel)
        {
            var ( name, address, age,injuryIds) = request;
            
          
            var patient = new Patient(name,address,age);
          
           
            var newPatient = await _patientRepository.AddAsync(patient);

            var setter = TypeAdapterConfig<Patient,PatientDto>.NewConfig()
                 .Map(dest => dest.Injury, src => src.Injuries.Select(i => i.Id)).MaxDepth(2);
            return Response.Success(newPatient.Adapt<Patient, PatientDto>(setter.Config),"Patient added successfully");
        }
    }
}
