using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZippingSlicedFiles
{
    public class ZippingSlicedFiles
    {
        private static List<string> partsNames = new List<string>();
        private static string extention = string.Empty;
        public static void Main()
        {
            Console.WriteLine("Insert number of parts:");
            int n = int.Parse(Console.ReadLine());
            Slice("sliceMe.mp4", n);
            AssembleZipps();

        }
        private static void Slice(string sourceFile, int parts)
        {
            extention = sourceFile.Substring(sourceFile.LastIndexOf('.'));
            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                var partSize = Math.Ceiling((double)(source.Length / parts));
                for (int i = 1; i <= parts; i++)
                {
                    string fileName = $"Part-{i}";
                    byte[] buffer = new byte[4096];
                    using (var destination = new FileStream(fileName+".gz", FileMode.Create))
                    {
                        using (var compressedFile = new GZipStream(destination, CompressionMode.Compress, false))
                        {
                            int currentBytes = 0;
                            partsNames.Add(fileName+".gz");

                            if (i >= 0 && i <= parts - 1)
                            {
                                while (currentBytes < partSize)
                                {
                                    int readBytes = source.Read(buffer, 0, buffer.Length);
                                    compressedFile.Write(buffer, 0, readBytes);
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
                                    compressedFile.Write(buffer, 0, readBytes);
                                }
                            }
                        }
                    }
                }
            }
        }
        private static void AssembleZipps()
        {
            var buffer = new byte[4096];
            using (var assambledFile = new FileStream("assambledFile.avi", FileMode.Create))
            {

                for (int i = 0; i < partsNames.Count; i++)
                {
                    using (var reader = new FileStream(partsNames[i], FileMode.Open))
                    {
                        using (var compressedFile = new GZipStream(reader, CompressionMode.Decompress, false))
                        {
                            while (true)
                            {
                                int readBytes = compressedFile.Read(buffer, 0, buffer.Length);
                                if (readBytes == 0)
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
    }
}
