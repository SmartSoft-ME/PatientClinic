using MediatR;

namespace Shared.Queries
{
    public interface IQuery<TOut> : IRequest<TOut> { }
}
