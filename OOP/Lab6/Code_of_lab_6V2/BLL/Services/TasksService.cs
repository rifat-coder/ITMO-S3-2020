using System;
using System.Collections.Generic;
using System.Linq;
using ReportManager.DAL.Entities;
using ReportManager.DAL.Repositories;

namespace ReportManager.BLL.Services
{
    public class TaskManageService
    {
        private IUnitOfWork _dataBase;

        public TaskManageService(IUnitOfWork database)
        {
            _dataBase = database;
        }

        public void Create(string name, Guid employeeId,
            string description = null, string comment = null)
        {
            _dataBase.AppContext.TasksRepository.Add(new Task(name, employeeId, _dataBase.AppContext.Time.Time, description, comment));
        }

        public void UpdateComment(string name, string comment)
        {
            var taskId = _dataBase.AppContext.TasksRepository.GetTaskByName(name).Id;
            var employeeId = _dataBase.AppContext.TasksRepository.GetTaskByName(name).IdOfStaffCh;
            if (_dataBase.AppContext.TasksRepository.GetTaskByName(name).Status != StatusOfTask.Active)
                UpdateState(name, StatusOfTask.Active);
            var commit = new TaskCommentCommit(taskId, employeeId,
                _dataBase.AppContext.TasksRepository.FindById(taskId).Comments, comment, _dataBase.AppContext.Time.Time);
            _dataBase.AppContext.TasksRepository.FindById(taskId).Comments = comment;
            _dataBase.AppContext.TasksRepository.FindById(taskId).AddNewCommit(commit);
            _dataBase.AppContext.CommitsRepository.Add(commit);
        }

        public void UpdateState(string name, StatusOfTask state)
        {
            var taskId = _dataBase.AppContext.TasksRepository.GetTaskByName(name).Id;
            var employeeId = _dataBase.AppContext.TasksRepository.GetTaskByName(name).IdOfStaffCh;
            var commit = new TaskStateCommit(taskId, employeeId,
                _dataBase.AppContext.TasksRepository.FindById(taskId).Status, state, _dataBase.AppContext.Time.Time);
            _dataBase.AppContext.TasksRepository.FindById(taskId).Status = state;
            _dataBase.AppContext.TasksRepository.FindById(taskId).AddNewCommit(commit);
            _dataBase.AppContext.CommitsRepository.Add(commit);
        }

        public void UpdateEmployee(string name,  Guid newEmployeeId)
        {
            var taskId = _dataBase.AppContext.TasksRepository.GetTaskByName(name).Id;
            var employeeId = _dataBase.AppContext.TasksRepository.GetTaskByName(name).IdOfStaffCh;
            if (_dataBase.AppContext.TasksRepository.FindById(taskId).Status != StatusOfTask.Active)
                UpdateState(name, StatusOfTask.Active);
            var commit = new TaskEmployeeCommit(taskId, employeeId,
                _dataBase.AppContext.TasksRepository.FindById(taskId).IdOfStaffCh, newEmployeeId, _dataBase.AppContext.Time.Time);
            _dataBase.AppContext.TasksRepository.FindById(taskId).IdOfStaffCh = newEmployeeId;
            _dataBase.AppContext.TasksRepository.FindById(taskId).AddNewCommit(commit);
            _dataBase.AppContext.CommitsRepository.Add(commit);
        }

        public Task GetTaskById(Guid id)
        {
            return _dataBase.AppContext.TasksRepository.FindById(id);
        }

        public Task GetTaskByLastCommit()
        {
            return _dataBase.AppContext.TasksRepository.GetAll().Where(x => x.ListOFCommits.Count != 0).
                           OrderBy(x => x.ListOFCommits.Last().DateCommit).Last();
        }

        public Task GetLastCreatedTask()
        {
            return _dataBase.AppContext.TasksRepository.GetAll().OrderBy(x => x.DateOfCreate).Last();
        }

        public List<Task> GetTasksOfEmployee(Guid employeeId)
        {
            return _dataBase.AppContext.TasksRepository.GetAll().Where(x => x.IdOfStaffCh == employeeId).ToList();
        }

        public List<Task> GetEditedTasks()
        {
            return _dataBase.AppContext.TasksRepository.GetAll().Where(x => x.ListOFCommits.Count != 0).ToList();
        }

        public List<Task> GetTasksOfSubordinates(Guid superiorId)
        {
            var tasks = new List<Task>();
            foreach (var task in _dataBase.AppContext.TasksRepository.GetAll())
            {
                if (_dataBase.AppContext.EmployeeRepository.FindById(task.IdOfStaffCh) is Staff employee && employee.DirectorId == superiorId)
                {
                    tasks.Add(task);
                }

            }
            return tasks;
        }

        public List<Task> GetTasksOfPeriod(int days)
        {
            return _dataBase.AppContext.TasksRepository.GetAll().Where(x => x.DateOfTaskChange >= _dataBase.AppContext.Time.Time.AddDays(-days)).ToList();
        }

        public List<Task> GetDailyTaskOfEmployee(Guid employeeId)
        {
            return _dataBase.AppContext.TasksRepository.GetAll().Where(x => x.DateOfTaskChange >= _dataBase.AppContext.Time.Time && x.IdOfStaffCh == employeeId).ToList();
        }

        public void CompleteTask(string name)
        {
            var taskId = _dataBase.AppContext.TasksRepository.GetTaskByName(name).Id;
            if (_dataBase.AppContext.TasksRepository.FindById(taskId).Status != StatusOfTask.Resolved)
            {
                UpdateState(name, StatusOfTask.Resolved);
                _dataBase.AppContext.TasksRepository.FindById(taskId).DateOfTaskChange = _dataBase.AppContext.Time.Time;
            }
        }

        public Task GetLastTaskOfEmployee(Guid employeeId)
        {
            return _dataBase.AppContext.TasksRepository.GetAll().Where(x => x.IdOfStaffCh == employeeId).
                           OrderBy(x => x.DateOfCreate).Last();
        }

        public Guid GetIdByName(string name)
        {
            return _dataBase.AppContext.TasksRepository.GetTaskByName(name).Id;
        }
    }
}