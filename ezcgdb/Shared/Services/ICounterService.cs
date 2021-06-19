using System.ServiceModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ezcgdb.Shared.Services
{
    [ServiceContract]
    public interface ICounterService
    {
        Task Increment();
        Task Decrement();
        Task ThrowException();

        IAsyncEnumerable<CounterState> SubscribeAsync();
    }
}