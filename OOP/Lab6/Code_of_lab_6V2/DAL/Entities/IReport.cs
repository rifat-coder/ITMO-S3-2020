using System;
using System.Collections.Generic;
using DAL.Entities;

namespace ReportManager.DAL.Entities
{
    public enum StatusOfReport
    {
        Open,
        Close
    }

    public interface IReport : IEntities
    {

        public List<Task> ListOfCompileTask { get; }

        public DateTime CreateDate { get; }

        public StatusOfReport Status { get; set; }

    }

    public class DailyReport : IReport
    {
        Guid IEntities.Id { get => Id; set => Guid.NewGuid(); }

        public Guid StaffIdCh { get; }

        public Guid Id { get; }

        public string Name { get; set; }

        public List<ICommit> ListOfChange { get; }

        public DateTime CreateDate { get; }

        public StatusOfReport Status { get; set; }

        public List<Task> ListOfCompileTask { get; }

        public DailyReport(Guid StaffChId, DateTime Time)
        {
            Status = StatusOfReport.Open;

            StaffIdCh = StaffChId;

            CreateDate = Time;

            ListOfChange = new List<ICommit>();

            Id = Guid.NewGuid();
        }

        public DailyReport(Guid StaffChId, List<ICommit> ListOfChange, List<Task> ListOfCompleTask, DateTime Time)
        {
            Status = StatusOfReport.Open;

            ListOfCompileTask = ListOfCompleTask;

            StaffIdCh = StaffChId;

            CreateDate = Time;

            Status = StatusOfReport.Open;

            this.ListOfChange = ListOfChange;

            Id = Guid.NewGuid();
        }
    }

    public class SprintReport : IReport
    {
        public Guid Id { get; }

        public string Name { get; set; }

        public StatusOfReport Status { get; set; }

        Guid IEntities.Id { get => Id; set => Guid.NewGuid(); }

        public DateTime CreateDate { get; }

        public List<DailyReport> ListOfDailyReport { get; }

        public List<Task> ListOfCompileTask { get; }

        public int NumberOfSprintDays { get; }

        public SprintReport(int QeuntOfSprintDay, DateTime Time)
        {

            CreateDate = Time;

            ListOfDailyReport = new List<DailyReport>();

            NumberOfSprintDays = QeuntOfSprintDay;

            Status = StatusOfReport.Open;
            
        }

        public SprintReport(List<DailyReport> ListOfReport,
                            List<Task> ListOfCompileTask,
                            int QeuntOfSprintDay, DateTime Time)
        {

            CreateDate = Time;

            ListOfDailyReport = ListOfReport;

            Status = StatusOfReport.Open;

            this.ListOfCompileTask = ListOfCompileTask;
            
            ListOfDailyReport = new List<DailyReport>();

            NumberOfSprintDays = QeuntOfSprintDay;

            Id = Guid.NewGuid();

        }
    }

    public class DirectorReport : IReport
    {
        
        public Guid Id { get; }

        public string Name { get; set; }

        public StatusOfReport Status { get; set; }

        public DateTime CreateDate { get; }

        public List<SprintReport> ListOfSprintReport { get; }

        public Guid StaffIdCh { get; }

        Guid IEntities.Id { get { return Id; } set => Guid.NewGuid(); }
        
        public List<Task> ListOfCompileTask { get; }
        
        public DirectorReport(Guid StaffIDCh)
        {

            CreateDate = DateTime.Today;

            ListOfSprintReport = new List<SprintReport>();

            StaffIdCh = StaffIDCh;
            
            Status = StatusOfReport.Open;
            
        }

        public DirectorReport(Guid StaffIdCh,
                                List<SprintReport> ListOFSprintRepot,
                                List<Task> ListOfCompiletask, DateTime Time)
        {

            CreateDate = Time;

            this.StaffIdCh = StaffIdCh;
            
            
            ListOfCompileTask = ListOfCompiletask;
            
            ListOfSprintReport = ListOFSprintRepot;

            ListOfSprintReport = new List<SprintReport>();

            Id = Guid.NewGuid();

            Status = StatusOfReport.Open;

        }
    }
}