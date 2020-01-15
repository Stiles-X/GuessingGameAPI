using System;
namespace API.Exceptions
{
    public class OutOfTriesException : InvalidOperationException
    {
        public OutOfTriesException() { }
        public OutOfTriesException(string message) : base(message) { }
    }
}
