using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoftProgram.Exceptions
{
    public class InvalidPathException:Exception
    {
        private const string InvalidPath = "The source does not exists.";
        public InvalidPathException() : base(InvalidPath)
        {

        }
        public InvalidPathException(string message) : base(message)
        {

        }
    }
}
