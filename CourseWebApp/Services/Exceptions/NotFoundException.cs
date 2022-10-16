using System;

namespace CourseWebApp.Services.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string message) : base(message)
    {

    }
}
