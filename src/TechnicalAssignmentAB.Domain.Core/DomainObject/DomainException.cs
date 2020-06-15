using System;

namespace TechnicalAssignmentAB.Domain.Core.DomainObject
{
    public class DomainException : Exception
    {
        public DomainException()
        {

        }

        public DomainException(string message) : base(message)
        {

        }

        public DomainException(string message, Exception innException) : base(message, innException)
        {

        }
    }
}
