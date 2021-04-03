using System;
using DAL.Repositories;
using ReportManager.DAL.Entities;

namespace DAL.ApplicationCore
{
    public class ApplicationContext
    {
        public IRepository<DailyReport> DailyReportRepository { get; set; }

        public IRepository<ICommit> CommitsRepository { get; set; }

        public IRepository<SprintReport> SprintReportRepository { get; set; }

        public IRepository<IStaff> EmployeeRepository { get; set; }

        public TaskRepository TasksRepository { get; set; }

        public FutuTime Time { get; set; }

        public IRepository<DirectorReport> DirectorReportRepository { get; set; }

        public ApplicationContext(IRepository<ICommit> commitsRepo,
                                  IRepository<IStaff> employeeRepo,          IRepository<DailyReport> dailyReportRepo,
                                  IRepository<SprintReport> sprintReportRepo, IRepository<DirectorReport> teamLeaderReportRepo,
                                  FutuTime time, TaskRepository tasksRepo)
        {
            this.Time = time;
            this.CommitsRepository = commitsRepo;
            this.EmployeeRepository = employeeRepo;
            this.TasksRepository = tasksRepo;
            this.DailyReportRepository = dailyReportRepo;
            this.SprintReportRepository = sprintReportRepo;
            this.DirectorReportRepository = teamLeaderReportRepo;
        }
    }

    
}
