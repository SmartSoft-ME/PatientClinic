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

namespace Application.Commands.PatientCommand.Handler
{
    internal class PatientInjuryHandler
    {
        private readonly IPatientRepository _patientRepository;
        public PatientInjuryHandler(IPatientRepository PRepository)
        {

            _patientRepository = PRepository;
        }
        public async Task<Response<PatientDto>> Handle(PatientInjuryCommand PIC, CancellationToken cancel)
        {
            var (id, type, treatment) = PIC;
            var patient=await _patientRepository.AddInjuryToPatient(id, type, treatment);
            return Response.Success(patient.Adapt<Patient, PatientDto>(), "Injury Added To Patient");

        }
    }
}
