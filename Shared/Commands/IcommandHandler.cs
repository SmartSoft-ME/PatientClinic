using MediatR;

namespace Shared.Commands
{
    public interface ICommandHandler<TIn, TOut> : IRequestHandler<TIn, Response<TOut>>
   where TIn : ICommand<TOut>
    { }
}
