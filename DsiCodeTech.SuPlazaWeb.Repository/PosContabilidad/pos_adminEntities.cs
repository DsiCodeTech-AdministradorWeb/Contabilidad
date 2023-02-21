using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodeTech.SuPlazaWeb.Repository.PosContabilidad
{
    public partial class pos_adminEntities: DbContext
    {
        public pos_adminEntities(string StringConnection) : base(StringConnection) { }
    }
}
