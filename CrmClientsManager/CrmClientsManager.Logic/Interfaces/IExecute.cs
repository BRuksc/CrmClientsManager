using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Application.Interfaces
{
    public interface IExecute<T>
    {
        public IResult<T> Execute(Func<T> action);
    }
}
