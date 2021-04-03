using System;
using System.Collections.Generic;
using DAL.Entities;

namespace ReportManager.DAL.Entities
{
    public interface IStaff : IEntities
    {

        public List<Staff> ListOfJuniorStaff {get; set;}

    }

    public class Staff : IStaff
    {
        public Guid Id { get; set; }

        public Guid? DirectorId { get; set; }

        public string Name { get; set; }

        public List<Staff> ListOfJuniorStaff { get; set; }

        public Staff(string Name)
        {

            this.Name = Name;

            ListOfJuniorStaff = new List<Staff>();

            Id = Guid.NewGuid();

        }

        public class Director
        {
            private Guid? DirectorID = null;

            private string Name;
            
            private List<Staff> ListOfJuniorStaff;

            public Director RenameName(string Name)
            {

                this.Name = Name;

                return this;

            }

            public Director RenameDirecroId(Guid DirectorID)
            {

                this.DirectorID = DirectorID;

                return this;
            }

            public Director AddStaffList(List<Staff> ListStaff)
            {

                ListOfJuniorStaff = ListStaff;

                return this;

            }

            public Staff AddStaff()
            {

                if (Name == null) { return null; }

                Staff staff = new Staff(Name);

                staff.ListOfJuniorStaff = ListOfJuniorStaff;

                staff.DirectorId = DirectorID;

                return staff;

            }
        }
    }

    public class Director : IStaff
    {

        public string Name { get; set; }

        public Guid Id { get; set; }
        
        public List<Staff> ListOfJuniorStaff { get; set; }

        public Director(string Name)
        {

            Id = Guid.NewGuid();

            this.Name = Name;

            ListOfJuniorStaff = new List<Staff>();

        }

        public class Builder
        {
            private string Name;

            private List<Staff> ListOfJuniorStaff = new List<Staff>();

            public Builder RenameName(string Name)
            {

                this.Name = Name;

                return this;

            }


            public Builder AddStaffList(List<Staff> StaffList)
            {

                ListOfJuniorStaff = StaffList;

                return this;

            }

            public Staff Build()
            {

                if (Name == null) { return null; }

                Staff NewStaffList = new Staff(Name);

                NewStaffList.ListOfJuniorStaff = ListOfJuniorStaff;

                return NewStaffList;

            }
        }
    }
}