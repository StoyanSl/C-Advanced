using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoftProgram
{
    public class BashSoftProgram
    {
        public static void Main()
        {
            Tester tester = new Tester();
            IOManager iOManager = new IOManager();
            StudentRepository repo = new StudentRepository(new RepositorySorter(), new RepositoryFilter());

            CommandInterpreter currentInterpreter = new CommandInterpreter(tester,repo,iOManager);
            InputReader reader = new InputReader(currentInterpreter);
            reader.StartReadingCommands();
        }
    }
}
