using System;
using System.Collections.Generic;
using System.Text;
using BashSoftProgram.Exceptions;

namespace BashSoftProgram.IO.Commands
{
    class DropDatabaseCommand:Command
    {
        public DropDatabaseCommand(string input, string[] data, Tester tester, StudentRepository repo, IOManager iOManager) : base(input, data, tester, repo, iOManager)
        {

        }
        public override void Execute()
        {
            if (Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
                

            }
            Repo.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }
    }
}
