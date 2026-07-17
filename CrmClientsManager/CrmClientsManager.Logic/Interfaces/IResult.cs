using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Application.Interfaces
{
    public interface IResult<T>
    {
        public T Value { get; set; }
        public bool IsSuccess { get; set; }
    }
}
