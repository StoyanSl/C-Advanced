using System;
using System.Collections.Generic;
using System.Text;
using BashSoftProgram.Exceptions;

namespace BashSoftProgram.IO.Commands
{
    class ChangeAbsolutePathCommand:Command
    {
        public ChangeAbsolutePathCommand(string input, string[] data, Tester tester, StudentRepository repo, IOManager iOManager) : base(input, data, tester, repo, iOManager)
        {

        }
        public override void Execute()
        {
            if (Data.Length == 2)
            {
                string absolutePath = Data[1];
                InputOutputManager.ChangeCurrentDirectoryAbsolute(absolutePath);
            }

            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
