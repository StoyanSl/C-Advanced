using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using BashSoftProgram.Exceptions;
namespace BashSoftProgram.IO.Commands
{
    public class OpenFileCommand:Command
    {
         public OpenFileCommand(string input, string[] data, Tester tester, StudentRepository repo, IOManager iOManager):base(input,data,tester,repo,iOManager)
        {

        }
        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
             
            }
            string fileName = this.Data[1];
            Process.Start(SessionData.currentPath + "\\" + fileName);
        }
    }
}
