using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SlicingFile
{
    private static List<string> partsNames = new List<string>();
    private static string extention = string.Empty;
    static void Main()
    {
        Console.WriteLine("Insert number of parts:");
        int n = int.Parse(Console.ReadLine());
        Slice("sliceMe.mp4", n);
        Assemble();
        Console.WriteLine("Done!");
    }
    private static void Slice(string sourceFile, int parts)
    {
        extention = sourceFile.Substring(sourceFile.LastIndexOf('.'));
        using (var source = new FileStream(sourceFile, FileMode.Open))
        {
            var partSize = Math.Ceiling((double)(source.Length / parts));
            for (int i = 1; i <= parts; i++)
            {
                string fileName = $"Part-{i}"+extention;
                byte[] buffer = new byte[4096];


                using (var destination = new FileStream(fileName, FileMode.Create))
                {

                    int currentBytes = 0;
                    partsNames.Add(fileName);
                    if (i >= 0 && i <= parts - 1)
                    {
                        while (currentBytes < partSize)
                        {
                            int readBytes = source.Read(buffer, 0, buffer.Length);
                            destination.Write(buffer, 0, readBytes);
                            currentBytes += readBytes;
                        }
                    }
                    else
                    {
                        while (true)
                        {
                            int readBytes = source.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0)
                            {
                                break;
                            }
                            destination.Write(buffer, 0, readBytes);
                        }
                    }

                }
            }
        }
    }
    private static void Assemble()
    {
        var buffer = new byte[4096];
        using (var assambledFile = new FileStream("assambledFile.avi", FileMode.Create))
        {

            for (int i = 0; i < partsNames.Count; i++)
            {
                using (var reader = new FileStream(partsNames[i], FileMode.Open))
                {
                    while(true)
                    {
                        int readBytes = reader.Read(buffer, 0, buffer.Length);
                        if (readBytes==0)
                        {
                            break;
                        }
                        assambledFile.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}

