using ReportManager.DAL.Repositories;

namespace ReportManager.BLL.Services
{
    public class ManageTimeService
    {
        private IUnitOfWork _dataBase;

        public ManageTimeService(IUnitOfWork database)
        {
            _dataBase = database;
        }

        public void NextDay()
        {
            _dataBase.AppContext.Time.NextDay();
        }

        public void NextMonth()
        {
            _dataBase.AppContext.Time.NextMonth();
        }
    }    
}