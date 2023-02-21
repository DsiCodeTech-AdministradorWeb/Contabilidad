using DsiCodeTech.Common.DataAccess.Infraestructure.Contract;
using DsiCodeTech.Common.Util;
using DsiCodeTech.SuPlazaWeb.Repository.PosContabilidad;
using System.Data.Entity;


namespace DsiCodeTech.SuPlazaWeb.Repository.Infraestructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly  pos_adminEntities _dbContext;

        public UnitOfWork()
        {
            _dbContext = new pos_adminEntities(SqlInjectConnection.ConnectionString());
        }

        public DbContext Db
        {
            get { return _dbContext; }
        }

        public void Dispose()
        {
        }
    }
}
