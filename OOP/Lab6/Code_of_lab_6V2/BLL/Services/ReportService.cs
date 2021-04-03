using System;
using System.Collections.Generic;
using System.Linq;
using ReportManager.DAL.Entities;
using ReportManager.DAL.Repositories;

namespace ReportManager.BLL.Services
{
    public class ReportManageService
    {
        private IUnitOfWork _dataBase;

        public ReportManageService(IUnitOfWork database)
        {
            _dataBase = database;
        }

        public void CreateDailyReport(Guid employee)
        {
            _dataBase.AppContext.DailyReportRepository.Add(new DailyReport(employee, _dataBase.AppContext.Time.Time));
        }

        public void AddDailyTasks(Guid employeeId, List<Task> tasks)
        {
            var reportId = GetLastDailyReportIdOfEmployee(employeeId);
            if (CheckDailyState(reportId))
            {
                foreach (var task in tasks)
                {
                    _dataBase.AppContext.DailyReportRepository.FindById(reportId).ListOfCompileTask.Add(task);
                }
            }
                
        }

        public void AddDailyChanges(Guid employeeId, List<ICommit> changes)
        {
            var reportId = GetLastDailyReportIdOfEmployee(employeeId);
            if (CheckDailyState(reportId))
            {
                foreach (var change in changes)
                {
                    _dataBase.AppContext.DailyReportRepository.FindById(reportId).ListOfChange.Add(change);
                }
            }
                
        }

        public Guid GetLastDailyReportIdOfEmployee(Guid employee)
        {
            return _dataBase.AppContext.DailyReportRepository.GetAll().Where(x => x.StaffIdCh == employee).OrderBy(x => x.CreateDate).Last().Id;
        }

        public DailyReport GetLastDailyReportOfEmployee(Guid employee)
        {
            return _dataBase.AppContext.DailyReportRepository.GetAll().OrderBy(x => x.CreateDate).Last();
        }

        private bool CheckDailyState (Guid reportId)
        {
            if (_dataBase.AppContext.DailyReportRepository.FindById(reportId).CreateDate.AddDays(1) > _dataBase.AppContext.Time.Time) { return true; }
            
            _dataBase.AppContext.DailyReportRepository.FindById(reportId).Status = StatusOfReport.Close;
            return false;
        }

        public List<DailyReport> GetReportsOfPeriod(int days)
        {
            return _dataBase.AppContext.DailyReportRepository.GetAll().Where(x => x.CreateDate >= _dataBase.AppContext.Time.Time.AddDays(-days)).ToList();
        }

        public void CreateSprintReport(int numberOfSprintDays)
        {
            _dataBase.AppContext.SprintReportRepository.Add(new SprintReport(numberOfSprintDays, _dataBase.AppContext.Time.Time));
        }

        public Guid GetLastSprintId()
        {
            return _dataBase.AppContext.SprintReportRepository.GetAll().OrderBy(x => x.CreateDate).Last().Id;
        }

        public SprintReport GetLastSprint()
        {
            return _dataBase.AppContext.SprintReportRepository.GetAll().OrderBy(x => x.CreateDate).Last();
        }

        public void AddReportsToSprint(SprintReport sprint, List<DailyReport> reports)
        {
            foreach (var report in reports) { sprint.ListOfDailyReport.Add(report); }
        }

        public void CompleteSprint(Guid reportId)
        {
            _dataBase.AppContext.SprintReportRepository.FindById(reportId).Status = StatusOfReport.Close;
        }

        public void CompleteReport(Guid reportId)
        {
            _dataBase.AppContext.DailyReportRepository.FindById(reportId).Status = StatusOfReport.Close;
        }

        public void CompleteTeamLeaderReport(Guid reportId)
        {
            _dataBase.AppContext.DirectorReportRepository.FindById(reportId).Status = StatusOfReport.Close;
        }

        public void CreateTeamLeaderReport(Guid teamLeaderId)
        {
            _dataBase.AppContext.DirectorReportRepository.Add(new DirectorReport(teamLeaderId));
        }

        public Guid GetLastTeamLeaderReportId()
        {
            return _dataBase.AppContext.DirectorReportRepository.GetAll().OrderBy(x => x.CreateDate).Last().Id;
        }

        public DirectorReport GetLastTeamLeaderReport()
        {
            return _dataBase.AppContext.DirectorReportRepository.GetAll().OrderBy(x => x.CreateDate).Last();
        }

        public void AddSprintsToTeamLeaderReport(DirectorReport sprint, SprintReport report)
        {
            if (report.Status == StatusOfReport.Close)
            {
                sprint.ListOfSprintReport.Add(report);
            }
                
        }

    }
}