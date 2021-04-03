using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Code_of_Lab_4
{

    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {
                List<FileInfo> ListOfFiles = new List<FileInfo> { new FileInfo("File1", 15), new FileInfo("File2", 20), new FileInfo("File3", 50) };
                CleanByMemSize LimByMemSize = new CleanByMemSize(100);
                CleanByQuantity LimByCount = new CleanByQuantity(3);
                DateTime LimTime = DateTime.Now;
                LimTime.AddSeconds(10);
                CleanByTime LimByTime = new CleanByTime(LimTime);
                CleanByHybrid MixLim = new CleanByHybrid(new List<IClean> { LimByMemSize, LimByCount, LimByTime });
                Backup backup = new Backup(ListOfFiles, LimByMemSize);
                backup.AddIncrementRersorePoint(100);
                backup.AddRestore(new List<FileInfo> { new FileInfo("File4", 10), new FileInfo("File5", 20) });
                backup.AddRestore(new List<FileInfo> { new FileInfo("File6", 30) });
                Console.WriteLine($"Количество точек {backup.ListOfRetoryPoints.Count}");
                Console.WriteLine($"Бэкап весит {backup.GetMemSizeOfBackup()} Мб");
                backup.RemovePoints();
                Console.WriteLine("После отчистки по памяти");
                Console.WriteLine($"Количество точек {backup.ListOfRetoryPoints.Count}");
                Console.WriteLine($"Бэкап весит {backup.GetMemSizeOfBackup()} Мб");
                backup.ContextClearPointsAlgo = new ContextClearPoints(LimByTime);
                Console.WriteLine($"{backup.ListOfRetoryPoints[0].ListOfFileInfo[0]} {backup.ListOfRetoryPoints[0].LastUpdate}");
                Thread.Sleep(10000);
                backup.AddRestore(ListOfFiles);
                Console.WriteLine("/// /// /// /// /// /// /// ///");
                Console.WriteLine($"Количество точек {backup.ListOfRetoryPoints.Count}");
                Console.WriteLine($"Бэкап весит {backup.GetMemSizeOfBackup()} Мб");
                backup.RemovePoints();
                Console.WriteLine("После отчистки по времени");
                Console.WriteLine($"Количество точек {backup.ListOfRetoryPoints.Count}");
                Console.WriteLine($"Бэкап весит {backup.GetMemSizeOfBackup()} Мб");

            }
            catch (Backup_Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine("RunTime " + elapsedTime);
            }
        }
    }
}
