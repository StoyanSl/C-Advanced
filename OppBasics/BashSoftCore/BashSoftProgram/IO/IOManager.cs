using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BashSoftProgram.Exceptions;

namespace BashSoftProgram
{
    public  class IOManager
    {
        public void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();
            var subFolders = new Queue<string>();
            subFolders.Enqueue(SessionData.currentPath);
            int initialIdentation = SessionData.currentPath.Split('\\').Length;
            while(subFolders.Count!=0)
            {
                string currentPath = subFolders.Dequeue();
                int identation = currentPath.Split('\\').Length-initialIdentation;
                if (depth-identation<0)
                {
                    break;
                }
                OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}",new string('-',identation),currentPath));
                try
                {

                    foreach (var file in Directory.GetFiles(currentPath))
                    {
                        int indexOfLastSlash = file.LastIndexOf('\\');
                        string filename = file.Substring(indexOfLastSlash);
                        OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + filename);
                    }
                    foreach (var directory in Directory.GetDirectories(currentPath))
                    {
                        int indexOfLastSlash = directory.LastIndexOf('\\');
                        string directoryName = directory.Substring(indexOfLastSlash);
                        OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + directoryName+" (directory)");
                    }
                    foreach (string directoryPath in Directory.GetDirectories(currentPath))
                    {
                        subFolders.Enqueue(directoryPath);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessExceptionMessage);
                }
            }
        }
        public void CreateDirectoryInCurrentFolder(string name)
        {
            string path = Directory.GetCurrentDirectory() + "\\" + name;
            try
            {
                Directory.CreateDirectory(path);
            }
            catch(ArgumentException)
            {
                throw new InvalidFileNameException();
            }
        }
        public void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if(relativePath=="..")
            {
                try
                {
                    string currentPath = SessionData.currentPath;
                    int indexOfLastSlash = currentPath.LastIndexOf("\\");
                    string newPath = currentPath.Substring(0, indexOfLastSlash);
                    SessionData.currentPath = newPath;
                }
                catch(ArgumentOutOfRangeException)
                {

                    throw new ArgumentOutOfRangeException("indexOfLastSlash",ExceptionMessages.UnableToGoHigherInPartitionHierarchy);
                }
            }
            else
            {
                string currentPath = SessionData.currentPath;
                currentPath+=  '\\'+relativePath;
                SessionData.currentPath = currentPath;
            }
        }
        public void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
              throw new InvalidPathException();
            
            }
            SessionData.currentPath = absolutePath;
        }
    }
}
