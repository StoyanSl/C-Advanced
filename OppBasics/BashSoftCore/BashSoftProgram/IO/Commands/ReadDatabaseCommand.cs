
using BashSoftProgram.Exceptions;

namespace BashSoftProgram.IO.Commands
{
    class ReadDatabaseCommand:Command
    {
        public ReadDatabaseCommand(string input, string[] data, Tester tester, StudentRepository repo, IOManager iOManager) : base(input, data, tester, repo, iOManager)
        {

        }
        public override void Execute()
        {
            if (Data.Length == 2)
            {
                string fileName = Data[1];
                Repo.LoadData(fileName);
            }
           
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
