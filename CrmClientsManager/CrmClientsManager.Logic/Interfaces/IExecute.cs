using CrmClientsManager.Application.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Application.Interfaces
{
    public interface IExecute<T>
    {
        public ErrorsContainer Errors { get; }
        public IResult<T> Execute(Func<T> action);
    }
}
