using System;
using System.Collections.Generic;
using System.Text;
using BashSoftProgram.Exceptions;

namespace BashSoftProgram.IO.Commands
{
    class PrintOrderedStudentsCommand:Command
    {
        public PrintOrderedStudentsCommand(string input, string[] data, Tester tester, StudentRepository repo, IOManager iOManager) : base(input, data, tester, repo, iOManager)
        {

        }
        public override void Execute()
        {
            if (Data.Length == 5)
            {
                string courseName = Data[1];
                string filter = Data[2].ToLower();
                string takeCommand = Data[3].ToLower();
                string takeQuantity = Data[4].ToLower();

                TryParseParametersForOrderAndTake(takeCommand, takeQuantity, courseName, filter);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
        private void TryParseParametersForOrderAndTake(string takeCommand, string takeQuantity, string courseName, string filter)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    Repo.OrderAndTake(courseName, filter);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        Repo.OrderAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeCommand);
            }
        }
    }
}
