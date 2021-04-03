using System;
using DAL.ApplicationCore;
using DAL.Repositories;
using ReportManager.DAL.Entities;

namespace ReportManager.DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        public ApplicationContext AppContext { get; set; }
    }

    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationContext AppContext { get; set; }

        public UnitOfWork (ApplicationContext context)
        {
            AppContext = context;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //TESTClass.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}