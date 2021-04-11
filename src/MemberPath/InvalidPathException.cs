using System;

namespace MemberPath
{
    public class InvalidPathException : Exception
    {
        public InvalidPathException()
            : base("Path is invalid")
        { }

        public InvalidPathException(string? message)
            : base(message)
        { }
    }
}
