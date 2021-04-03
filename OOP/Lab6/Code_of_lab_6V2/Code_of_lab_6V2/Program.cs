using System;
using DAL.ApplicationCore;
using DAL.Repositories;
using ReportManager.BLL.Services;
using ReportManager.DAL.Repositories;
using BLL.Services;
using DAL;

namespace Code_of_lab_6V2
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new FutuTime();
            var commitRepo = new CommitRepository();
            var employeeRepo = new StaffRepository();
            var tasksRepo = new TaskRepository();
            var dailyReportRepo = new DailyReportRepository();
            var sprintRepo = new SprintReportRepository();
            var teamLeaderRepo = new DirectorReportRepository();

            var database = new UnitOfWork(new ApplicationContext(commitRepo, employeeRepo,dailyReportRepo, sprintRepo, teamLeaderRepo, timer, tasksRepo));

            var commitServ = new CommitManageService(database);
            var employeeServ = new StaffManageService(database);
            var reportServ = new ReportManageService(database);
            var tasksServ = new TaskManageService(database);
            var timerServ = new ManageTimeService(database);

            var HomeConntroller = new HomeController(new ApplicationContextSer(commitServ, employeeServ, reportServ, tasksServ, timerServ));

            HomeConntroller.AddNewStaff("Rifat");
            HomeConntroller.AddNewStaff("Tema");
            HomeConntroller.AddNewStaff("Artur");


        }
    }
}
