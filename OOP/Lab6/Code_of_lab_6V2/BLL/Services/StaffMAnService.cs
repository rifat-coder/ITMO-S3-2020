using System;
using System.Collections.Generic;
using System.Linq;
using ReportManager.DAL.Entities;
using ReportManager.DAL.Repositories;

namespace ReportManager.BLL.Services
{
    public class StaffManageService
    {
        private IUnitOfWork DataOfUnitOFWorkPattern;

        public StaffManageService(IUnitOfWork NewData)
        {
            DataOfUnitOFWorkPattern = NewData;
        }

        public void ChangeDirector(Guid IdOfStaff, Guid IDOfDirector)
        {
            if (DataOfUnitOFWorkPattern.AppContext.EmployeeRepository.FindById(IdOfStaff) is Staff NewStaff)
            {
                if (NewStaff.DirectorId != null) { DataOfUnitOFWorkPattern.AppContext.EmployeeRepository.FindById((Guid)NewStaff.DirectorId).ListOfJuniorStaff.Remove(NewStaff); }

                NewStaff.DirectorId = IDOfDirector; IStaff director = DataOfUnitOFWorkPattern.AppContext.EmployeeRepository.FindById(IDOfDirector);

                director.ListOfJuniorStaff.Add(NewStaff);

            }
        }

        public void DeleteJunStaff(Guid StaffId, Guid JunId)
        {
            DataOfUnitOFWorkPattern.AppContext.EmployeeRepository.FindById(StaffId).ListOfJuniorStaff.Remove((Staff)DataOfUnitOFWorkPattern.AppContext.EmployeeRepository.FindById(JunId));
        }

        public void AddNewStaff(string name) { DataOfUnitOFWorkPattern.AppContext.EmployeeRepository.Add(new Staff(name)); }

        public Guid GetId(string name) { return DataOfUnitOFWorkPattern.AppContext.EmployeeRepository.FindId(name); }

        public void AddToListStaff(Guid staffId, Guid JunStaffId)
        {
            DataOfUnitOFWorkPattern.AppContext.EmployeeRepository.FindById(staffId).ListOfJuniorStaff.Add((Staff)DataOfUnitOFWorkPattern.AppContext.EmployeeRepository.FindById(JunStaffId));
        }

        public void SetDirectorForStaff(string Name) { DataOfUnitOFWorkPattern.AppContext.EmployeeRepository.Add(new Director(Name)); }

        public Director GetJunList()
        {
            List<IStaff> ListOfStaff = DataOfUnitOFWorkPattern.AppContext.EmployeeRepository.GetAll();

            return (Director) ListOfStaff.Single(x => x is Director);
        }

        public string FindStaffById(Guid id) { return DataOfUnitOFWorkPattern.AppContext.EmployeeRepository.FindById(id).Name; }
    }

}
