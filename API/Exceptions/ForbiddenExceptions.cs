using System;
using System.Collections.Generic;
using System.Text;
namespace APIProject.Exceptions
{
    public class ForbiddenException : InvalidOperationException
    {
        public ForbiddenException() { }
        public ForbiddenException(string paramName)
           : base("Param: " + paramName) { ParamName = paramName; }
        public ForbiddenException(string paramName, string message)
            : base(GetMsg(message, paramName)) { ParamName = paramName; }
        public virtual string ParamName { get; }
        public static string GetMsg(string message, string paramName)
            => message + ", Param: " + paramName;
    }
}
