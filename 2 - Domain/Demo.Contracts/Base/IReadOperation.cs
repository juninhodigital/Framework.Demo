using System.Collections.Generic;

namespace Demo.Contracts
{
    public interface IReadOperation<T>
    {
        IEnumerable<T> Get();
    }
}
