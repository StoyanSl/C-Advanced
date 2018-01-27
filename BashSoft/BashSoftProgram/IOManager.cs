using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoftProgram
{
    public static class IOManager
    {
        public static void TraverseDirectory(string path)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentation = path.Split('\\').Length;
            var subFolders = new Queue<string>();
            subFolders.Enqueue(path);
            while(subFolders.Count!=0)
            {
                string currentPath = subFolders.Dequeue();
                int identation = currentPath.Split('\\').Length;
                OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}",new string('-',identation),currentPath));
                foreach(string directoryPath in Directory.GetDirectories(currentPath) )
                {
                    subFolders.Enqueue(directoryPath);
                }
            }
        }
    }
}
