using System;
using System.Diagnostics;

namespace Code_of_Lab_1
{
    
    class Program
    {
        static void Main(string[] args)
        {
            
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {

                Search search = new Search("/Users/rifat/Documents/Projects/ITMO-S3-2020/OOP/Lab1/Code_of_Lab-1/Code_of_Lab-1/file.ini");
                search.read_ini_file();
                var varible_s = search.finder("[COMMON]", "StatisterTimeMs");
                Console.WriteLine($"{varible_s} - {varible_s.GetType()}");
                
            }
            catch (Local_Exception ex)
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
