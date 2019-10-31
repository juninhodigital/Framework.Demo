using Demo.Model;

namespace Demo.Contracts
{
    public interface IClient : ICrudOperations<Client>, IReadCompactOperation<ClientCompact>
    {

    }
}
