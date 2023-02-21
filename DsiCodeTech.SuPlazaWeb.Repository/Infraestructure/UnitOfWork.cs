using DsiCodeTech.SuPlazaWeb.Repository.Infraestructure.Contract;
using DsiCodeTech.SuPlazaWeb.Repository.PosContabilidad;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DsiCodeTech.Common.DataAccess.Infraestructure.Contract;
using DsiCodeTech.Common.Util;


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
