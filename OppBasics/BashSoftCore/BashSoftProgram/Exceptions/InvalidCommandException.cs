using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoftProgram.Exceptions
{
    class InvalidCommandException : Exception
    {
        private const string invalidCommandMessage = "The command '{0}' is invalid";
        private const string invalidCommand = "The given command is invalid";
        public InvalidCommandException(string message) : base(string.Format(invalidCommandMessage,message)) { }
        public InvalidCommandException() : base(invalidCommand) { }
     
    }
}
