using System;

namespace FinancialManegementConsole.Entities.Exceptions
{
    internal class DomainException : ApplicationException
    {
        public DomainException(string message) : base(message) { }
        
    }
 }

