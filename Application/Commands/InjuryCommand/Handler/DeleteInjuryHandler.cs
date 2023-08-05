using Application.Commands.InjuryCommands;
using Application.DTO;
using Application.IRepositories;
using MediatR;
using Shared.Commands;
using Shared;
using Mapster;
using Domain;

namespace Application.Commands.InjuryCommand.Handler
{
    internal class DeleteInjuryHandler: ICommandHandler<DeleteInjuryCommand, Unit>
    {
        private readonly IInjuryRepository _Irepository;
       
        public DeleteInjuryHandler(IInjuryRepository Irepository)
        {
            _Irepository = Irepository;
            
        }
        public async Task<Response<Unit>> Handle(DeleteInjuryCommand request, CancellationToken cancel)
        {
            var injury = await _Irepository.GetByIdAsync(request.id, cancel);
            if (injury.Pa != null)
                foreach (var patient in injury.Pa)
                    injury.Pa.Remove(patient);
            await _Irepository.UpdateAsync(injury);
            await _Irepository.DeleteAsync(request.id, cancel);
            return Response.Success(Unit.Value, "Deleted Post");
         }


    }
}
