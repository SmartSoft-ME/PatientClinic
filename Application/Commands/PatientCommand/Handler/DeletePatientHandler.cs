using Application.Commands.InjuryCommands;
using Application.DTO;
using Application.IRepositories;
using MediatR;
using Shared.Commands;
using Shared;
using Mapster;
using Domain;
using Application.Commands.PatientCommands;

namespace Application.Commands.PatientCommand.Handler
{
    internal class DeletePatientHandler : ICommandHandler<DeletePatientCommand, Unit>
    {
        private readonly IPatientRepository _patientRepository;
        public async Task<Response<Unit>> Handle(DeletePatientCommand request, CancellationToken cancel)
        {
            var patient = await _patientRepository.GetByIdAsync(request.id, cancel);
            if (patient.Injuries != null)
                foreach (var injury in patient.Injuries)
                    patient.Injuries.Remove(injury);
            await _patientRepository.UpdateAsync(patient);
            await _patientRepository.DeleteAsync(request.id, cancel);
            return Response.Success(Unit.Value, "Treatement done");
        }
    }
}
