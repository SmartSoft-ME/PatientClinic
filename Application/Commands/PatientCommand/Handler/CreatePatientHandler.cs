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
        public async Task<Response<PatientDto>> Handle(CreatePatientCommand CPC,CancellationToken cancel)
        {
            var ( name, address, age,injuryIds) = CPC;
            var InjuryPatient = new List<Injury>();
            foreach(var InjuryId in injuryIds)
            {
                InjuryPatient.Add(await _injuryRepository.GetByIdAsync(InjuryId,cancel));
            }
            var patient = new Patient(name,address,age,InjuryPatient);
          
           
            var newPatient = await _patientRepository.AddAsync(patient);

           
            return Response.Success(newPatient.Adapt<Patient, PatientDto>(),"Patient added successfully");
        }
    }
}
