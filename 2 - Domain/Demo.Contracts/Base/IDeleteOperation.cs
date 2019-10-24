namespace Demo.Contracts
{
    public interface IDeleteOperation<T>
    {
        void Delete(T input);
    }

    public interface IDeleteOperation
    {
        void Delete(int id);
    }
}
