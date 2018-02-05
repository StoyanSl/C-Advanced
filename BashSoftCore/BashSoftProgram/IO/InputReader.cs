using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoftProgram
{
   public static class InputReader
    {
        private const string endCommand = "quit";
        public static void StartReadingCommands()
        {
            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                string input = Console.ReadLine().Trim();
                if (input==endCommand)
                {
                    break;  
                }
                CommandInterpreter.InterpedCommand(input);
            }
        }
    }
}
