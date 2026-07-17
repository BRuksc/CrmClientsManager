using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Application.Resources
{
    public static class ErrorsMessages
    {
        public const string SqlConnectionError =
        "Unable to establish a connection with the database.";

        public const string SqlExecutionError =
            "An error occurred while executing a database command.";

        public const string SqlTimeoutError =
            "The database operation exceeded the allowed execution time.";

        public const string SqlDeadlockError =
            "The database operation was interrupted due to a transaction conflict.";

        public const string SqlConstraintError =
            "The operation cannot be completed because it violates a database constraint.";

        public const string SqlPermissionError =
            "The current user does not have sufficient database permissions.";

        public const string SqlUnknownError =
            "An unknown database error occurred.";

        public const string ConnectionTimeoutError =
            "The connection attempt timed out.";

        public const string NetworkError =
            "A network error occurred while communicating with an external service.";

        public const string InvalidOperationError =
            "The requested operation cannot be performed in the current application state.";

        public const string ArgumentError =
            "An invalid argument was provided.";

        public const string NullReferenceError =
            "A required object was not initialized.";

        public const string InvalidCastError =
            "An internal type conversion error occurred.";

        public const string FormatError =
            "The provided data has an invalid format.";

        public const string DataMappingError =
            "An error occurred while converting database data.";

        public const string SerializationError =
            "An error occurred while processing application data.";

        public const string UnauthorizedAccessError =
            "You do not have permission to perform this operation.";

        public const string OperationCancelledError =
            "The operation was cancelled.";

        public const string UnknownError =
            "An unexpected error occurred.";
    }
}
