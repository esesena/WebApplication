using System;

namespace CourseWebApp.Services.Exceptions;

public class DbConcurrencyException : ApplicationException
{
    public DbConcurrencyException(string message) : base(message)
    {

    }
}
