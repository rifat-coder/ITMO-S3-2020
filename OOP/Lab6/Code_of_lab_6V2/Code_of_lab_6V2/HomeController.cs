using System;
using System.Collections.Generic;
using BLL.Services;
using ReportManager.BLL.Services;
using ReportManager.DAL.Entities;

namespace Code_of_lab_6V2
{
    public class HomeController
    {
        public ApplicationContextSer ControlllerContext { get; set; }
        private CommitManageService _CommitService { get; set; }
        private StaffManageService _EmployeeService { get; set; }
        private ReportManageService _ReportService { get; set; }
        private ManageTimeService _TimerService { get; set; }
        private TaskManageService _TasksService { get; set; }

        public HomeController(ApplicationContextSer context)
        {
            ControlllerContext = context;
            _CommitService = context.CommitManageService;
            _EmployeeService = context.StaffManageService;
            _ReportService = context.ReportManageService;
            _TimerService = context.ManageTimeService;
            _TasksService = context.TasksManageService;
        }

        public List<ICommit> GetCommitsOfPeriod(int days)
        {
            return _CommitService.GetCommitsOfPeriod(days);
        }

        public List<ICommit> GetDailyCommitsOfEmployee(Guid employeeId)
        {
            return _CommitService.GetDailyCommitsOfEmployee(employeeId);
        }

        public void AddNewStaff(string name)
        {
            _EmployeeService.AddNewStaff(name);
        }

        public void UpdateSuperior(string employeeName, string subordinateName)
        {
            _EmployeeService.ChangeDirector(_EmployeeService.GetId(employeeName), _EmployeeService.GetId(subordinateName));
        }

        public void AddSubordinate(string employeeName, string subordinateName)
        {

            _EmployeeService.AddToListStaff(_EmployeeService.GetId(employeeName), _EmployeeService.GetId(subordinateName));
        }

        public void RemoveSubordinate(string employeeName, string subordinateName)
        {
            _EmployeeService.DeleteJunStaff(_EmployeeService.GetId(employeeName), _EmployeeService.GetId(subordinateName));
        }

        public void SetTeamLeader(string name)
        {
            _EmployeeService.SetDirectorForStaff(name);
        }

        public Guid GetId(string name)
        {
            return _EmployeeService.GetId(name);
        }

        public void ShowHierarchy()
        {
            var leader = _EmployeeService.GetJunList();
            Console.WriteLine("The team leader is - {0}.", leader.Name);
            var employees = new Queue<Staff>(leader.ListOfJuniorStaff);
            while (employees.Count != 0)
            {
                var next = employees.Dequeue();
                Console.WriteLine("A subordinate of {0} is {1}.", _EmployeeService.FindStaffById((Guid)next.DirectorId), next.Name);
                foreach (var sub in next.ListOfJuniorStaff)
                    employees.Enqueue(sub);
            }
        }

        public void CreateDailyReport(Guid employee)
        {
            _ReportService.CreateDailyReport(employee);
        }

        public void AddDailyTasks(Guid employeeId, List<Task> tasks)
        {
            _ReportService.AddDailyTasks(employeeId, tasks);
        }

        public void AddDailyChanges(Guid employeeId, List<ICommit> changes)
        {
            _ReportService.AddDailyChanges(employeeId, changes);
        }

        public Guid GetLastDailyReportIdOfEmployee(Guid employee)
        {
            return _ReportService.GetLastDailyReportIdOfEmployee(employee);
        }

        public DailyReport GetLastDailyReportOfEmployee(Guid employee)
        {
            return _ReportService.GetLastDailyReportOfEmployee(employee);
        }

        public List<DailyReport> GetReportsOfPeriod(int days)
        {
            return _ReportService.GetReportsOfPeriod(days);
        }

        public void CreateSprintReport(int numberOfSprintDays)
        {
            _ReportService.CreateSprintReport(numberOfSprintDays);
        }

        public Guid GetLastSprintId()
        {
            return _ReportService.GetLastSprintId();
        }

        public SprintReport GetLastSprint()
        {
            return _ReportService.GetLastSprint();
        }

        public void AddReportsToSprint(SprintReport sprint, List<DailyReport> reports)
        {
            _ReportService.AddReportsToSprint(sprint, reports);
        }

        public void CompleteSprint(Guid reportId)
        {
            _ReportService.CompleteSprint(reportId);
        }

        public void CompleteReport(Guid reportId)
        {
            _ReportService.CompleteReport(reportId);
        }

        public void CompleteTeamLeaderReport(Guid reportId)
        {
            _ReportService.CompleteTeamLeaderReport(reportId);
        }

        public void CreateTeamLeaderReport(Guid teamLeaderId)
        {
            _ReportService.CreateTeamLeaderReport(teamLeaderId);
        }

        public Guid GetLastTeamLeaderReportId()
        {
            return _ReportService.GetLastTeamLeaderReportId();
        }

        public DirectorReport GetLastTeamLeaderReport()
        {
            return _ReportService.GetLastTeamLeaderReport();
        }

        public void AddSprintsToTeamLeaderReport(DirectorReport sprint, SprintReport report)
        {
            _ReportService.AddSprintsToTeamLeaderReport(sprint, report);
        }

        public void NextDay()
        {
            _TimerService.NextDay();
        }

        public void NextWeek()
        {
            _TimerService.NextMonth();
        }

        public void Create(string name, Guid employeeId,
            string description = null, string comment = null)
        {
            _TasksService.Create(name, employeeId, description, comment);
        }

        public void UpdateComment(string name, string comment)
        {
            _TasksService.UpdateComment(name, comment);
        }

        public void UpdateEmployee(string name, Guid newEmployeeId)
        {
            _TasksService.UpdateEmployee(name, newEmployeeId);
        }

        public void UpdateState(string name, StatusOfTask state)
        {
            _TasksService.UpdateState(name, state);
        }

        public Task GetTaskById(Guid id)
        {
            return _TasksService.GetTaskById(id);
        }

        public Task GetTaskByLastCommit()
        {
            return _TasksService.GetTaskByLastCommit();
        }

        public Task GetLastCreatedTask()
        {
            return _TasksService.GetLastCreatedTask();
        }

        public List<Task> GetTasksOfEmployee(Guid employeeId)
        {
            return _TasksService.GetTasksOfEmployee(employeeId);
        }

        public List<Task> GetEditedTasks()
        {
            return _TasksService.GetEditedTasks();
        }

        public List<Task> GetTasksOfSubordinates(Guid superiorId)
        {
            return _TasksService.GetTasksOfSubordinates(superiorId);
        }

        public List<Task> GetTasksOfPeriod(int days)
        {
            return _TasksService.GetTasksOfPeriod(days);
        }

        public void CompleteTask(string name)
        {
            _TasksService.CompleteTask(name);
        }

        public Task GetLastTaskOfEmployee(Guid employeeId)
        {
            return _TasksService.GetLastTaskOfEmployee(employeeId);
        }

        public Guid GetIdByName(string name)
        {
            return _TasksService.GetIdByName(name);
        }

        public List<Task> GetDailyTaskOfEmployee(Guid employeeId)
        {
            return _TasksService.GetDailyTaskOfEmployee(employeeId);
        }
    }

}
