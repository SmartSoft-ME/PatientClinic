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
        private readonly IValidator<Patient> _validator;
        private readonly IPatientRepository _patientRepository;
        public CreatePatientHandler( IPatientRepository Prepository,IValidator<Patient> validator)
        {
           _validator=validator;
            _patientRepository = Prepository;
        }
        public async Task<Response<PatientDto>> Handle(CreatePatientCommand CPC,CancellationToken cancel)
        {
            var ( name, addresse, age) = CPC;

            var patient = new Patient(name,addresse,age);
            var validation = await _validator.ValidateAsync(patient);
            if(! validation.IsValid ) { throw new ValidationException(validation.Errors); }
            var newpatient = await _patientRepository.AddAsync(patient);

           
            return Response.Success(newpatient.Adapt<Patient, PatientDto>(),"Patient added succesufly");
        }
    }
}
