using System;
using ReportManager.BLL.Services;

namespace BLL.Services
{
    public class ApplicationContextSer : IDisposable
    {

        public StaffManageService StaffManageService { get; set; }

        public ReportManageService ReportManageService { get; set; }

        public ManageTimeService ManageTimeService { get; set; }

        public CommitManageService CommitManageService { get; set; }

        public TaskManageService TasksManageService { get; set; }
        

        public ApplicationContextSer(CommitManageService CommitService, StaffManageService EmployeeService,
            ReportManageService ReportService, TaskManageService TasksService, ManageTimeService TimerService)
        {
            this.CommitManageService = CommitService;
            this.StaffManageService = EmployeeService;
            this.ReportManageService = ReportService;
            this.TasksManageService = TasksService;
            this.ManageTimeService = TimerService;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //TESTClass.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
