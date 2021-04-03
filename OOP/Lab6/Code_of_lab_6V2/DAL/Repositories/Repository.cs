using System;
using System.Collections.Generic;
using System.Linq;
using ReportManager.DAL.Entities;

namespace DAL.Repositories
{
    // Make template ReportRepository
    public class ReportRepository
    {
        public ReportRepository()
        {
        }
    }
    // still empty

    public interface IRepository<T> where T : class
    {

        public void Add(T entity);

        public T FindById(Guid id);

        public Guid FindId(string name);

        public List<T> GetAll();

    }

    public class EntitiesRepository : IRepository<IReport>
    {
        private List<IReport> ListOfReports = new List<IReport>();

        public void Add(IReport NewReport) { ListOfReports.Add(NewReport); }

        public IReport FindById(Guid Id) { return ListOfReports.Single(x => x.Id == Id); }

        public List<IReport> GetAll() { return ListOfReports; }

        public Guid FindId(string Name) { return ListOfReports.Single(x => x.Name == Name).Id; }
    }

    public class TaskRepository : IRepository<Task>
    {
        private List<Task> ListOfTask = new List<Task>();

        public void Add(Task NewTask) { ListOfTask.Add(NewTask); }

        public Guid FindId(string name) { return ListOfTask.Single(x => x.Name == name).Id; }

        public Task GetTaskByName(string name)
        {
            return ListOfTask.Single(x => x.Name == name);
        }

        public Task FindById(Guid id)
        {
            return ListOfTask.Single(x => x.Id == id);
        }
        public List<Task> GetAll()
        {
            return ListOfTask;
        }
    }

    public class SprintReportRepository : IRepository<SprintReport>
    {
        private List<SprintReport> ListOfSprintreports = new List<SprintReport>();

        public void Add(SprintReport NewReport)
        {
            ListOfSprintreports.Add(NewReport);
        }

        public List<SprintReport> GetAll()
        {

            return ListOfSprintreports;

        }

        public Guid FindId(string name)
        {

            return ListOfSprintreports.Single(x => x.Name == name).Id;

        }

        public SprintReport FindById(Guid id)
        {
            return ListOfSprintreports.Single(x => x.Id == id);
        }
        
    }

    public class DailyReportRepository : IRepository<DailyReport>
    {
        private List<DailyReport> ListOfDailyReport = new List<DailyReport>();

        public void Add(DailyReport NewReport) { ListOfDailyReport.Add(NewReport); }

        public DailyReport FindById(Guid id) { return ListOfDailyReport.Single(x => x.Id == id); }

        public Guid FindId(string name) { return ListOfDailyReport.Single(x => x.Name == name).Id; }

        public List<DailyReport> GetAll() {  return ListOfDailyReport; }
    }

    public class DirectorReportRepository : IRepository<DirectorReport>
    {
        private List<DirectorReport> ListOfDirectorReports = new List<DirectorReport>();

        public void Add(DirectorReport NewReport) { ListOfDirectorReports.Add(NewReport); }

        public List<DirectorReport> GetAll()
        {
            return ListOfDirectorReports;
        }

        public Guid FindId(string name) { return ListOfDirectorReports.Single(x => x.Name == name).Id; }

        public DirectorReport FindById(Guid id) { return ListOfDirectorReports.Single(x => x.Id == id); }

    }

    public class CommitRepository : IRepository<ICommit>
    {

        private readonly List<ICommit> ListOfCommitsRepository = new List<ICommit>();

        public void Add(ICommit NewStaff)
        {
            ListOfCommitsRepository.Add(NewStaff);
        }

        public List<ICommit> GetAll()
        {
            return ListOfCommitsRepository;
        }

        public Guid FindId(string name) { return ListOfCommitsRepository.Single(x => x.Name == name).Id; }

        public ICommit FindById(Guid id) {  return ListOfCommitsRepository.Single(x => x.IdCommit == id); }

    }

    public class StaffRepository : IRepository<IStaff>
    {
        private readonly List<IStaff> ListOfStaffRepository = new List<IStaff>();

        public void Add(IStaff NewStaff) { ListOfStaffRepository.Add(NewStaff); }

        public List<IStaff> GetAll()
        {
            return ListOfStaffRepository;
        }

        public Guid FindId(string name) { return ListOfStaffRepository.Single(x => x.Name == name).Id; }

        public IStaff FindById(Guid id) { return ListOfStaffRepository.Single(x => x.Id == id); }

    }
}
