using System;
namespace APIProject.Exceptions
{
    public class OutOfTriesException : InvalidOperationException
    {
        public OutOfTriesException() { }
        public OutOfTriesException(string message) : base(message) { }
    }
}
