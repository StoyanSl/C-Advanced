using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryTraversal
{
    class DirectoryTraversal
    {
        private static Dictionary<string, int> extentionCounter = new Dictionary<string, int>();
        private static Dictionary<string, Dictionary<string, decimal>> headDict = new Dictionary<string, Dictionary<string, decimal>>();
        static void Main()
        {
            Console.WriteLine("Insert Valid Directory Path:");
            string path = Console.ReadLine();
            traversingDirectoryAndStoringFilesData(path);
            SortingAndWritingData();

        }
        private static void traversingDirectoryAndStoringFilesData(string directoryPath)
        {
            var subFolders = new Queue<string>();
            subFolders.Enqueue(directoryPath);
            while (subFolders.Count != 0)
            {
                string currentPath = subFolders.Dequeue();
                foreach (string filePath in Directory.GetFiles(currentPath))
                {
                    string fileName = filePath.Substring(1 + filePath.LastIndexOf('\\'));
                    string fileExtention = fileName.Substring(fileName.LastIndexOf('.'));
                    long fileSize = new FileInfo(filePath).Length;
                    Decimal fileSizeInKb = Convert.ToDecimal(fileSize) / (1024.0m);
                    if (!extentionCounter.ContainsKey(fileExtention))
                    {
                        extentionCounter.Add(fileExtention, 1);
                        headDict.Add(fileExtention, new Dictionary<string, decimal>());
                        headDict[fileExtention].Add(fileName, fileSizeInKb);
                    }
                    else
                    {
                        extentionCounter[fileExtention]++;
                    }
                    if (!headDict[fileExtention].ContainsKey(fileName))
                    {
                        headDict[fileExtention].Add(fileName, fileSizeInKb);
                    }

                }
                foreach (string directory in Directory.GetDirectories(currentPath))
                {
                    subFolders.Enqueue(directory);
                }
            }
        }
        private static void SortingAndWritingData()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\report.txt";
            using (var writer = new StreamWriter(path))
            {
                foreach (var extention in extentionCounter.OrderByDescending(n => n.Value).ThenBy(s => s.Key))
                {

                    foreach (var groupOfFilesByExtentions in headDict)
                    {
                        if (extention.Key == groupOfFilesByExtentions.Key)
                        {
                            writer.WriteLine(extention.Key);
                            foreach (var files in groupOfFilesByExtentions.Value.OrderBy(s => s.Value))
                            {
                                writer.WriteLine($"--{files.Key} - {String.Format("{0:0.000}", files.Value)}kb");
                            }
                        }
                    }
                }


            }
        }
    }
}
