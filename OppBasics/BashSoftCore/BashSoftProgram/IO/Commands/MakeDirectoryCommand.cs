using System;
using System.Collections.Generic;
using System.Text;
using BashSoftProgram.Exceptions;
namespace BashSoftProgram.IO.Commands
{
    class MakeDirectoryCommand:Command
    {
        public MakeDirectoryCommand(string input, string[] data, Tester tester, StudentRepository repo, IOManager iOManager) : base(input, data, tester, repo, iOManager)
        {

        }
        public override void Execute()
        {
            if (Data.Length == 2)
            {
                string folderName = Data[1];
                this.InputOutputManager.CreateDirectoryInCurrentFolder(folderName);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
