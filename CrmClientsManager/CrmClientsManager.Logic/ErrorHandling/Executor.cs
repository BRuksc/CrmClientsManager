using CrmClientsManager.Application.Interfaces;
using CrmClientsManager.Application.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Text;

namespace CrmClientsManager.Application.ErrorHandling
{
    public class Executor<T> : IExecute<T>
    {
        public ErrorsContainer Errors { get; private set; } = new();

        public IResult<T> Execute(Func<T> action)
        {
            Errors = new ErrorsContainer();

            try
            {
                var result = action();

                return new Result<T>
                {
                    IsSuccess = true,
                    Value = result
                };
            }
            catch (SqlException ex)
            {
                Errors.Criticals.Add(new Error
                {
                    Message = GetSqlExceptionMessage(ex)
                });

                return Failure<T>();
            }
            catch (ValidationException ex)
            {
                Errors.Warnings.Add(new Error
                {
                    Message = ex.Message
                });

                return Failure<T>();
            }
            catch (UnauthorizedAccessException)
            {
                Errors.Criticals.Add(new Error
                {
                    Message = ErrorsMessages.UnauthorizedAccessError
                });

                return Failure<T>();
            }
            catch (ArgumentException)
            {
                Errors.Criticals.Add(new Error
                {
                    Message = ErrorsMessages.ArgumentError
                });

                return Failure<T>();
            }
            catch (InvalidOperationException)
            {
                Errors.Criticals.Add(new Error
                {
                    Message = ErrorsMessages.InvalidOperationError
                });

                return Failure<T>();
            }
        }


        private IResult<T> Failure<T>()
        {
            return new Result<T>
            {
                IsSuccess = false
            };
        }


        private string GetSqlExceptionMessage(SqlException exception)
        {
            return exception.Number switch
            {
                -2 => ErrorsMessages.SqlTimeoutError,
                1205 => ErrorsMessages.SqlDeadlockError,
                _ => ErrorsMessages.SqlExecutionError
            };
        }
    }
}
