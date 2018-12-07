using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Domain.Exceptions
{
    public class BooksDomainException : Exception
    {
        public BooksDomainException()
        { }

        public BooksDomainException(string message)
            : base(message)
        { }

        public BooksDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
