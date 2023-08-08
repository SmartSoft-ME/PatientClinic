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
        private readonly IInjuryRepository _IRepository;
        
        public DeleteInjuryHandler(IInjuryRepository IRepository)
        {
            _IRepository = IRepository;
            
        }
        public async Task<Response<Unit>> Handle(DeleteInjuryCommand request, CancellationToken cancel)
        {
            var injury = await _IRepository.GetByIdAsync(request.id, cancel);
           
            
            await _IRepository.DeleteAsync(request.id, cancel);
            return Response.Success(Unit.Value, "Deleted Injury");
         }


    }
}
