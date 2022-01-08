using System.Threading;
using System.Threading.Tasks;

namespace KittenApi.BusinessLayer.Abstractions
{
    public interface IHandler<in TRequest, TResponse>
    {
        public Task<TResponse> HandleAsync(TRequest request, CancellationToken token);
    }
    
    public interface IHandler<TResponse>
    {
        public Task<TResponse> HandleAsync(CancellationToken token);
    }
}