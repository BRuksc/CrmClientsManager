using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Application.ErrorHandling
{
    public class ErrorsContainer
    {
        public IList<Error> Warnings { get; set; } = new List<Error>();
        public IList<Error> Criticals { get; set; } = new List<Error>();
    }
}
