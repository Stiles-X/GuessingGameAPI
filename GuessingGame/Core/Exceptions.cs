using System;
using System.Collections.Generic;
using System.Text;
#nullable enable
namespace GuessingGame.Core.Exceptions
{
    public class PropertyNotSetException : InvalidOperationException
    {
        public PropertyNotSetException() { }
        public PropertyNotSetException(string? paramName)
            : base("Param: "+paramName) { ParamName = paramName; }
        public PropertyNotSetException(string? paramName, string? message)
            : base(GetMsg(message, paramName)) { ParamName = paramName; }
        public virtual string? ParamName { get; }
        public static string? GetMsg(string? message, string? paramName)
            => message + ", Param: " + paramName;
    }
    public class OutOfTriesException : InvalidOperationException
    {
        public OutOfTriesException() { }
        public OutOfTriesException(string? message) : base(message) { }
    }
    public class ForbiddenException : InvalidOperationException
    {
        public ForbiddenException() { }
        public ForbiddenException(string? paramName)
           : base("Param: " + paramName) { ParamName = paramName; }
        public ForbiddenException(string? paramName, string? message)
            : base(GetMsg(message, paramName)) { ParamName = paramName; }
        public virtual string? ParamName { get; }
        public static string? GetMsg(string? message, string? paramName)
            => message + ", Param: " + paramName;
    }
}
