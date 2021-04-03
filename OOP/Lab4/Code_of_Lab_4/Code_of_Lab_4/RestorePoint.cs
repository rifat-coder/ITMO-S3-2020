using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Code_of_Lab_4
{
    /// <summary>
    /// Interface for an incremental point and a full point
    /// </summary>
    public interface IRestorePoint
    {

        public double MemorySize { get; }

        public DateTime LastUpdate { get; set; }

        public List<FileInfo> ListOfFileInfo { get; }

        public void AddNewListOfFiles(List<FileInfo> ListOfFiles);

        public void RemoveListOfFiles(List<FileInfo> ListOfFiles);

        public FileInfo FindFile(string Name);

    }
    /// <summary>
    /// Implementation of the incremental point class
    /// </summary>
    public class RestorePointIncrement : IRestorePoint
    {
        public double MemorySize { get; }

        public double Delta { get; }

        public DateTime LastUpdate { get; set; }

        public List<FileInfo> ListOfFileInfo { get; }

        public RestorePointIncrement(List<FileInfo> NewFiles, int DeltaInt)
        {
            Debug.Assert(NewFiles != null, "NewFiles is null!");

            LastUpdate = new DateTime();
            LastUpdate = DateTime.Now;

            ListOfFileInfo = NewFiles;

            Delta = DeltaInt;

            MemorySize += Delta;
        }
        /// <summary>
        /// Adding new files to this current point
        /// </summary>
        /// <param name="NewFiles"></param>
        public void AddNewListOfFiles(List<FileInfo> NewFiles)
        {
            Debug.Assert(NewFiles != null, "NewFiles is null!");
            foreach (FileInfo file in NewFiles) { ListOfFileInfo.Add(new FileInfo(file.NameOfFile, file.SizeOfMemory)); }

            LastUpdate = DateTime.Now;
        }
        /// <summary>
        /// Deleting current files from this point
        /// </summary>
        /// <param name="NewFiles"></param>
        public void RemoveListOfFiles(List<FileInfo> NewFiles)
        {
            Debug.Assert(NewFiles != null, "NewFiles is null!");
            foreach (FileInfo CurNewFile in NewFiles)
            {
                ListOfFileInfo.Remove(ListOfFileInfo.Find(CurrentFile => CurrentFile.NameOfFile == CurNewFile.NameOfFile));
            }

            LastUpdate = DateTime.Now;
        }
        /// <summary>
        /// Getting file by his name
        /// </summary>
        /// <param name="Name"></param>
        /// <returns>Object FileInfo</returns>
        public FileInfo FindFile(string Name)
        {
            return ListOfFileInfo.Find(file => file.NameOfFile == Name);
        }
    }
    /// <summary>
    /// Implementation of the full point class
    /// </summary>
    public class RestorePoint : IRestorePoint
    {
        public double MemorySize { get; }

        public Guid Id { get; }

        public List<FileInfo> ListOfFileInfo { get; }

        public DateTime LastUpdate { get; set; }

        public RestorePoint(List<FileInfo> NewListOfFiles)
        {
            Debug.Assert(NewListOfFiles != null, "NewFiles is null!");
            Id = Guid.NewGuid();

            ListOfFileInfo = new List<FileInfo>();

            AddNewListOfFiles(NewListOfFiles);

            MemorySize = ListOfFileInfo.Sum(file => file.SizeOfMemory);

            LastUpdate = new DateTime();
            LastUpdate = DateTime.Now;
        }
        /// <summary>
        /// Adding new files to this current point
        /// </summary>
        /// <param name="NewListOfFiles"></param>
        public void AddNewListOfFiles(List<FileInfo> NewListOfFiles)
        {
            Debug.Assert(NewListOfFiles != null, "NewFiles is null!");
            foreach (FileInfo CurFile in NewListOfFiles)
            {
                ListOfFileInfo.Add(CurFile);
            }
            LastUpdate = DateTime.Now;
        }
        /// <summary>
        ///  Deleting current files from this point
        /// </summary>
        /// <param name="NewListOfFiles"></param>
        public void RemoveListOfFiles(List<FileInfo> NewListOfFiles)
        {
            Debug.Assert(NewListOfFiles != null, "NewFiles is null!");
            foreach (FileInfo CurNewFile in NewListOfFiles)
            {
                ListOfFileInfo.Remove(ListOfFileInfo.Find(CurrentFile => CurrentFile.NameOfFile == CurNewFile.NameOfFile));
            }
                
            LastUpdate = DateTime.Now;
        }
        /// <summary>
        /// Getting file by his name
        /// </summary>
        /// <param name="Name"></param>
        /// <returns>Object FileInfo</returns>
        public FileInfo FindFile(string Name)
        {
            return ListOfFileInfo.Find(file => file.NameOfFile == Name);
        }
    }


}
