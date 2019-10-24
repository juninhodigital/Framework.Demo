namespace Demo.Contracts
{
    public interface ICreateOperation<T>
    {
        int Save(T input);
    }
}
