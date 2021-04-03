using System;
using System.Collections.Generic;
using DAL.Entities;

namespace ReportManager.DAL.Entities
{
    public enum StatusOfTask
    {
        Open,
        Active,
        Resolved
    }

    public class Task : IEntities
    {
        
        public Guid Id { get; set;}
        public string Name { get; set;}
        
        public DateTime? DateOfTaskChange { get; set; }

        public Guid IdOfStaffCh  { get; set;}

        public string Comments { get; set;}

        public string Description { get; set; }

        public List<ICommit> ListOFCommits { get; set; }

        public StatusOfTask Status { get; set;}

        public DateTime DateOfCreate { get; }

        public Task (string Name, Guid IdOfStaff, DateTime Time, string Description = null, string Comment = null)
        {

            this.Name = Name;

            Id = Guid.NewGuid();

            IdOfStaffCh = IdOfStaff;

            Comments = Comment;

            DateOfTaskChange = null;

            this.Description = Description;

            ListOFCommits = new List<ICommit>();

            Status = StatusOfTask.Open;

            DateOfCreate = Time;
            
        }
        
        public Task(Task Task_)
        {

            Id = Task_.Id;

            Name = Task_.Name;

            DateOfTaskChange = Task_.DateOfTaskChange;

            DateOfCreate = Task_.DateOfCreate;

            IdOfStaffCh = Task_.IdOfStaffCh;

            Status = Task_.Status;

            Description = Task_.Description;
           
            Comments = Task_.Comments;

        }

        public bool CheckListOfCommitEmpty()
        {

            if (ListOFCommits.Count != 0)
            {
                return true;
            }
            else
            {
                return false;

            }

        }

        public void AddNewCommit(ICommit NewCommit)
        {

            ListOFCommits.Add(NewCommit);

        }

        
    }
}