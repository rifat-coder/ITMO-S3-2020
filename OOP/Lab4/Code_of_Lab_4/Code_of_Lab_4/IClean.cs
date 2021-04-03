using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Code_of_Lab_4
{
    /// <summary>
    /// The IClean interface is common to all class of Strategy.
    /// It declares a method the ContextClearPoints uses to execute a strategy.
    /// </summary>
    public interface IClean
    {
        public List<IRestorePoint> CleanListOfPoints(List<IRestorePoint> ListOfPointsForCleaning);
    }
    /// <summary>
    /// CleanByMemSize implement an algorithm the ContextClearPoints uses.
    /// </summary>
    public class CleanByMemSize : IClean
    {

        public double LimitOfMemorySize;

        public CleanByMemSize(double LimMemSize) { LimitOfMemorySize = LimMemSize; }

        public List<IRestorePoint> CleanListOfPoints(List<IRestorePoint> ListOfPointsForCleaning)
        {
            Debug.Assert(ListOfPointsForCleaning != null, "ListOfPointsForCleaning is null!");
            List<IRestorePoint> NewListOfResoryPointAfterCleaning = ListOfPointsForCleaning;

            double MemSizeOfAllRestoryPoints = ListOfPointsForCleaning.Sum(file => file.MemorySize);

            foreach (IRestorePoint CurrentResPoint in ListOfPointsForCleaning.ToList())
            {
                if (MemSizeOfAllRestoryPoints > LimitOfMemorySize)
                {
                    NewListOfResoryPointAfterCleaning.Remove(CurrentResPoint);

                    MemSizeOfAllRestoryPoints -= CurrentResPoint.MemorySize;
                }
            }

            return NewListOfResoryPointAfterCleaning;
        }
    }
    /// <summary>
    /// CleanByTime implement an algorithm the ContextClearPoints uses.
    /// </summary>
    public class CleanByTime : IClean
    {
        public DateTime LimitOfDateForRestorePoint;

        public CleanByTime(DateTime Date) { LimitOfDateForRestorePoint = Date; }

        public List<IRestorePoint> CleanListOfPoints(List<IRestorePoint> ListOfPointsForCleaning)
        {
            return ListOfPointsForCleaning.Where(CurrentRestPoint => CurrentRestPoint.LastUpdate.CompareTo(LimitOfDateForRestorePoint) <= 0).ToList();
        }
    }
    /// <summary>
    /// CleanByQuantityt implement an algorithm the ContextClearPoints uses.
    /// </summary>
    public class CleanByQuantity : IClean
    {
        public int LimitOfQuantityRestorePoints;

        public CleanByQuantity(int LimitOfQuantity) { LimitOfQuantityRestorePoints = LimitOfQuantity; }

        public List<IRestorePoint> CleanListOfPoints(List<IRestorePoint> ListOfPointsForCleaning)
        {
            Debug.Assert(ListOfPointsForCleaning != null, "ListOfPointsForCleaning is null!");

            int QuantityOfPoints = ListOfPointsForCleaning.Count;

            if (QuantityOfPoints < LimitOfQuantityRestorePoints)
            {
                return ListOfPointsForCleaning;
            }

            int counter = LimitOfQuantityRestorePoints;

            while (ListOfPointsForCleaning.TakeLast(counter).First() is RestorePointIncrement)
            {
                counter++;
            }

            return ListOfPointsForCleaning.TakeLast(counter).ToList();
        }
    }
    /// <summary>
    /// CleanByHybrid implement an algorithm the ContextClearPoints uses.
    /// </summary>
    public class CleanByHybrid : IClean
    {
        public List<IClean> ListOfTypesCleaning { get; }

        public CleanByHybrid(List<IClean> NewListOfTypesClean) { ListOfTypesCleaning = NewListOfTypesClean; }

        public List<IRestorePoint> CleanListOfPoints(List<IRestorePoint> ListOfPointsForCleaning)
        {
            Debug.Assert(ListOfPointsForCleaning != null, "ListOfPointsForCleaning is null!");

            List<IRestorePoint> NewListOfResoryPointAfterCleaning = new List<IRestorePoint>();

            foreach (IClean CurrentTypeOfClean in ListOfTypesCleaning)
            { NewListOfResoryPointAfterCleaning.AddRange(CurrentTypeOfClean.CleanListOfPoints(ListOfPointsForCleaning)); }

            return NewListOfResoryPointAfterCleaning;
        }
    }
    /// <summary>
    /// The ContextClearPoints calls the execution method on the linked
    /// strategy object each time it needs to run the algorithm.
    /// The ContextClearPoints doesn’t know what type of strategy
    /// it works with or how the algorithm is executed.
    /// </summary>
    public class ContextClearPoints
    {
        /// <summary>
        ///  A reference to one of the concrete Strategy.
        /// </summary>
        public IClean ContextCleaner { get; }
        /// <summary>
        /// Assigning a reference to a Clean
        /// Clients of the ContextClearPoints must associate it with a suitable
        /// action that matches the way they expect
        /// the ContextClearPoints to perform its primary job.
        /// </summary>
        /// <param name="NewCleaner"></param>
        public ContextClearPoints(IClean NewCleaner)
        {
            Debug.Assert(NewCleaner != null, "NewCleaner is null!");
            this.ContextCleaner = NewCleaner;
        }
        /// <summary>
        /// Performing a cleanup
        /// </summary>
        /// <param name="ListOfPointsForClean"></param>
        /// <returns>New list after clearing</returns>
        public List<IRestorePoint> Make(List<IRestorePoint> ListOfPointsForClean)
        {
            Debug.Assert(ListOfPointsForClean != null, "ListOfPointsForClean is null!");
            return ContextCleaner.CleanListOfPoints(ListOfPointsForClean);
        }
    }

}
