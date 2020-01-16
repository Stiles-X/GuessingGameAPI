using System;

namespace APIProject.Exceptions
{
    public class PropertyNotSetException : InvalidOperationException
    {
        public PropertyNotSetException() { }
        public PropertyNotSetException(string paramName)
            : base("Param: "+paramName) { ParamName = paramName; }
        public PropertyNotSetException(string paramName, string message)
            : base(GetMsg(message, paramName)) { ParamName = paramName; }
        public virtual string ParamName { get; }
        public static string GetMsg(string message, string paramName)
            => message + ", Param: " + paramName;

        public PropertyNotSetException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
