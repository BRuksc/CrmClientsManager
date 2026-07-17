using CrmClientsManager.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Application.ErrorHandling
{
    public sealed class Result<T> : IResult<T>
    {
        private T _value;
        private bool _isSuccess;

        public T Value
        {
            get => _value;
            set
            {
                if (_value == null)
                {
                    _value = value;
                }
            }
        }
        public bool IsSuccess 
        {
            get => _isSuccess; 
            set
            {
                if (_isSuccess == null)
                {
                    _isSuccess = value;
                }
            }
        }
    }
}
