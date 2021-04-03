using System;
using System.IO;

namespace Code_of_Lab_4
{
    /// <summary>
    /// Entity with file information
    /// </summary>
    public class FileInfo
    {
        public string NameOfFile { get; }

        public double SizeOfMemory { get; }

        public string ParentDirectory { get; }

        public bool Exists { get; }

        public DateTime DateOfCreation { get; set; }
        
        public FileInfo(string name, double MemSize)
        {
            NameOfFile = name;

            SizeOfMemory = MemSize;

            Exists = true;

            ParentDirectory = "/";

            DateOfCreation = DateTime.Now;
        }
    }
}
