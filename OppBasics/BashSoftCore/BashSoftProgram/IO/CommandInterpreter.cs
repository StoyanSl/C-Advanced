using System;
using System.IO;
using BashSoftProgram.Exceptions;
using BashSoftProgram.IO.Commands;

namespace BashSoftProgram
{
    public  class CommandInterpreter
    {
        private Tester judge;
        private StudentRepository repo;
        private IOManager iOManager;
        public CommandInterpreter(Tester judge, StudentRepository repo, IOManager iOManager)
        {
            this.judge = judge;
            this.repo = repo;
            this.iOManager = iOManager;
        }
        public void InterpedCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0];
            try
            {
                Command command = this.ParseCommand(input, commandName, data);
                command.Execute();
            }
            catch (DirectoryNotFoundException dnfe)
            {
                OutputWriter.DisplayException(dnfe.Message);
            }
            catch (FileNotFoundException fnfe)
            {
                OutputWriter.DisplayException(fnfe.Message);
            }
            catch (ArgumentOutOfRangeException aoore)
            {
                OutputWriter.DisplayException(aoore.Message);
            }
            catch (ArgumentException ae)
            {
                OutputWriter.DisplayException(ae.Message);
            }
            catch(Exception e)
            {
                OutputWriter.DisplayException(e.Message);
            }
        }

            private  Command ParseCommand(string input, string command, string[] data)
        {
            switch (command)
            {
                case "open":
                    return new OpenFileCommand(input, data, this.judge, this.repo, this.iOManager);
                  
                case "mkdir":
                    return new MakeDirectoryCommand(input, data, this.judge, this.repo, this.iOManager);
                    
                case "ls":
                    return new TraverseFoldersCommand(input, data, this.judge, this.repo, this.iOManager);
                    
                case "cmp":
                    return new CompareFilesCommand(input, data, this.judge, this.repo, this.iOManager);
                    
                case "cdRel":
                    return new ChangeRelativePathCommand(input, data, this.judge, this.repo, this.iOManager);
              
                case "cd":
                    return new ChangeAbsolutePathCommand(input, data, this.judge, this.repo, this.iOManager);
                   
                case "readDB":
                    return new ReadDatabaseCommand(input, data, this.judge, this.repo, this.iOManager);
                case "dropDB":
                    return new DropDatabaseCommand(input, data, this.judge, this.repo, this.iOManager);
                case "help":
                    return new GetHelpCommand(input, data, this.judge, this.repo, this.iOManager);
                
                case "show":
                    return new ShowCourseCommand(input, data, this.judge, this.repo, this.iOManager);
                    
                case "filter":
                    return new PrintFilteredStudentsCommand(input, data, this.judge, this.repo, this.iOManager);
                  
                case "order":
                    return new PrintOrderedStudentsCommand(input, data, this.judge, this.repo, this.iOManager);
               
                default:
                    throw new InvalidCommandException(input);
                   
            }
        }
     

        
    }
}
