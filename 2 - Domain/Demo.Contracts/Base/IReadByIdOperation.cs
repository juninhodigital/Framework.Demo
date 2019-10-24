namespace Demo.Contracts
{
    public interface IReadByIdOperation<T>
    {
        T GetByID(int ID);
    }
}
