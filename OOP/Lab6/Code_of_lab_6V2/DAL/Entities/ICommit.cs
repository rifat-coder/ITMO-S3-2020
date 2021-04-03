
using System;
using DAL.Entities;

namespace ReportManager.DAL.Entities
{
    public interface ICommit : IEntities
    {

        public DateTime DateCommit { get; }

        public Guid StaffIdCh { get; }

        public Guid IdOfTask { get; }

        public Guid IdCommit { get; }

    }

    public class TaskCommentCommit : ICommit
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid IdOfTask { get; }

        public DateTime DateCommit { get; }

        public string OldComment { get; }

        public Guid IdCommit { get; }

        public string NewComment { get; }
        
        public Guid StaffIdCh { get; }
        
        
        public TaskCommentCommit(Guid taskId, Guid employeeId, string prev, string update, DateTime time)
        {
            IdCommit = Guid.NewGuid();

            DateCommit = time;

            IdOfTask = taskId;

            OldComment = prev;

            NewComment = update;

            StaffIdCh = employeeId;
            
        }
    }

    public class TaskEmployeeCommit : ICommit
    {
        public string Name { get; set; }

        public Guid Id { get; set; }
        
        public Guid IdOfTask { get; }

        public Guid StaffIdCh { get; }

        public Guid NewStaffId { get; }

        public DateTime DateCommit { get; }

        public Guid IdCommit { get; }
        
        public Guid OldStaffId { get; }
        

        public TaskEmployeeCommit(Guid taskId, Guid employeeId, Guid prev, Guid update, DateTime time)
        {
            
            IdOfTask = taskId;

            NewStaffId = update;

            StaffIdCh = employeeId;

            DateCommit = time;
            
            OldStaffId = prev;

            IdCommit = Guid.NewGuid();
        }
    }

    public class TaskStateCommit : ICommit
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCommit { get; }

        public Guid IdCommit { get; }

        public Guid StaffIdCh { get; }

        public Guid IdOfTask { get; }

        public StatusOfTask NewStatus { get; }

        public StatusOfTask OldStatus { get; }

        public TaskStateCommit(Guid IdTask, Guid StaffId, StatusOfTask Old, StatusOfTask NewStatus, DateTime TimeCommit)
        {
            
            IdOfTask = IdTask;

            StaffIdCh = StaffId;

            DateCommit = TimeCommit;

            OldStatus = Old;

            this.NewStatus = NewStatus;

            IdCommit = Guid.NewGuid();

        }
    }


}