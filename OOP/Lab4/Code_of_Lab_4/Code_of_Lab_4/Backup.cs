using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Code_of_Lab_4
{
    /// <summary>
    /// A class with which you can make a backup, delete points and add points
    /// </summary>
    public class Backup
    {

        public ContextClearPoints ContextClearPointsAlgo { get; set; }

        public List<IRestorePoint> ListOfRetoryPoints    { get; set; }

        public Backup(IClean TypeOfClean)
        {
            Debug.Assert(TypeOfClean != null, "TypeOfClean is null!");

            ContextClearPointsAlgo = new ContextClearPoints(TypeOfClean);

            ListOfRetoryPoints = new List<IRestorePoint>();

        }

        public Backup(List<FileInfo> NewListFiles, IClean TypeOfClean)
        {
            Debug.Assert(NewListFiles != null, "NewListFiles is null!");
            Debug.Assert(TypeOfClean != null, "TypeOfClean is null!");

            ContextClearPointsAlgo = new ContextClearPoints(TypeOfClean);

            ListOfRetoryPoints = new List<IRestorePoint>();

            AddRestore(NewListFiles);

        }
        /// <summary>
        /// Method that creates a new point with files
        /// </summary>
        /// <param name="ListNewFiles"></param>
        public void AddRestore(List<FileInfo> ListNewFiles)
        {
            Debug.Assert(ListNewFiles != null, "Files is null!");

            if (ListOfRetoryPoints == null)
            {
                throw new Backup_Exception("ListOfRetoryPoints is null! FILE: Backup.cs");
            }

            ListOfRetoryPoints.Add(new RestorePoint(ListNewFiles));
        }
        /// <summary>
        /// Method that creates a new increment point
        /// </summary>
        /// <param name="Delta"></param>
        public void AddIncrementRersorePoint(int Delta)
        {
            if (ListOfRetoryPoints == null)
            {
                throw new Backup_Exception("ListOfRetoryPoints is null! FILE: Backup.cs");
            }

            if (ListOfRetoryPoints[0] is RestorePointIncrement)
            {
                throw new Backup_Exception("First point is increment! FILE: Backup.cs");
            }

            ListOfRetoryPoints.Add(new RestorePointIncrement(ListOfRetoryPoints[ListOfRetoryPoints.Count - 1].ListOfFileInfo, Delta));
        }
        /// <summary>
        /// Clearing points by the  current algorithm
        /// </summary>
        public void RemovePoints()
        {
            Debug.Assert(ContextClearPointsAlgo != null, "ContextClearPointsAlgo is null!");
            ListOfRetoryPoints = ContextClearPointsAlgo.Make(ListOfRetoryPoints);
        }
        /// <summary>
        /// Get total size all points
        /// </summary>
        /// <returns>Total memory all points</returns>
        public double GetMemSizeOfBackup()
        {
            return ListOfRetoryPoints.Sum(point => point.MemorySize);
        }

        public void AddFilesToLatestPoint(List<FileInfo> ListOfNewFiles)
        {
            Debug.Assert(ListOfNewFiles != null, "ListOfNewFiles is null!");

            IRestorePoint lastPoint = GetLastPoint();

            lastPoint.AddNewListOfFiles(ListOfNewFiles);

        }

        public IRestorePoint GetLastPoint()
        {
            return ListOfRetoryPoints[ListOfRetoryPoints.Count - 1];
        }

        public IEnumerable<IRestorePoint> GetRestorePoints()
        {
            return ListOfRetoryPoints;
        }

        public FileInfo FindFileInResorePoint(string NameOfFile)
        {

            FileInfo file = new FileInfo(NameOfFile, 0);

            foreach (IRestorePoint point in ListOfRetoryPoints)
            {
                FileInfo FoundFile = point.ListOfFileInfo.Find(x => x.NameOfFile.Contains(NameOfFile));
                if (file == FoundFile)
                {
                    return FoundFile;
                }
            }

            return null;
        }
    }
    
}
