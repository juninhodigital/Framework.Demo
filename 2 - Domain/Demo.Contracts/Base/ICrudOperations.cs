namespace Demo.Contracts
{
    public interface ICrudOperations<T> : ICreateOperation<T>, IReadOperation<T>, IReadByIdOperation<T>, IUpdateOperation<T>, IDeleteOperation<T>
    {
    }
}
