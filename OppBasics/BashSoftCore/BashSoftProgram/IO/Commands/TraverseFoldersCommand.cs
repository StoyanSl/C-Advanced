using System;
using System.Collections.Generic;
using System.Text;
using BashSoftProgram.Exceptions;

namespace BashSoftProgram.IO.Commands
{
    class TraverseFoldersCommand:Command
    {
        public TraverseFoldersCommand(string input, string[] data, Tester tester, StudentRepository repo, IOManager iOManager) : base(input, data, tester, repo, iOManager)
        {

        }
        public override void Execute()
        {
            if (Data.Length == 1)
            {
                InputOutputManager.TraverseDirectory(0);
            }
            else if (Data.Length == 2)
            {
                int depth;
                bool hasParsed = int.TryParse(Data[1], out depth);
                if (hasParsed)
                {
                    InputOutputManager.TraverseDirectory(depth);
                }
                else
                {
                    throw new InvalidCommandException(this.Input);
                }
            }
        }
    }
}
