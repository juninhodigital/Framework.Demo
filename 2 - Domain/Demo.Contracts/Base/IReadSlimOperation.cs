using System.Collections.Generic;

namespace Demo.Contracts
{
    public interface IReadCompactOperation<T>
    {
        IEnumerable<T> GetCompact();
    }
}
