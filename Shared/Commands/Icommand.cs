using MediatR;


namespace Shared.Commands
{
    public interface ICommand<T> : IRequest<Response<T>> { }
}
