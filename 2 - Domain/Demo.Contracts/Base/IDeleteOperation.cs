namespace Demo.Contracts
{
    public interface IDeleteOperation<T>
    {
        int Delete(T input);
    }

    public interface IDeleteOperation
    {
        int Delete(int id);
    }
}
