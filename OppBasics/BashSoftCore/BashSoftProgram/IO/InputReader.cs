using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoftProgram
{
   public  class InputReader
    {
        private CommandInterpreter commandInterpreter;
        public InputReader(CommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        private const string endCommand = "quit";
        public  void StartReadingCommands()
        {
            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                string input = Console.ReadLine().Trim();
                if (input==endCommand)
                {
                    break;  
                }
                commandInterpreter.InterpedCommand(input);
            }
        }
    }
}
