using System;
using System.Collections.Generic;
using System.Linq;
using ReportManager.DAL.Entities;
using ReportManager.DAL.Repositories;

namespace ReportManager.BLL.Services
{
    public class CommitManageService
    {
        private IUnitOfWork DataOfUnitOFWorkPattern;

        public CommitManageService(IUnitOfWork NewData)
        {
            DataOfUnitOFWorkPattern = NewData;
        }

        public List<ICommit> GetCommitsOfPeriod(int days)
        {
            return DataOfUnitOFWorkPattern.AppContext.CommitsRepository.GetAll().Where(x => x.DateCommit >= DataOfUnitOFWorkPattern.AppContext.Time.Time.AddDays(-days)).ToList();
        }

        public List<ICommit> GetDailyCommitsOfEmployee(Guid employeeId)
        {
            return DataOfUnitOFWorkPattern.AppContext.CommitsRepository.GetAll().Where(x => x.DateCommit >= DataOfUnitOFWorkPattern.AppContext.Time.Time && x.StaffIdCh == employeeId).ToList();
        }
    }
}