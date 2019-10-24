using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Contracts
{
    public interface IUnitOfWork
    {
        IUser Usuario { get; }
        IClient Cliente { get; }
    }
}
