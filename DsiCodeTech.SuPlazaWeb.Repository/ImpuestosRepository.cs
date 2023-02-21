using DsiCodeTech.Common.DataAccess.Infraestructure.Contract;
using DsiCodeTech.SuPlazaWeb.Repository.Infraestructure;
using DsiCodeTech.SuPlazaWeb.Repository.Infraestructure.Contract;
using DsiCodeTech.SuPlazaWeb.Repository.PosContabilidad;

namespace DsiCodeTech.SuPlazaWeb.Repository
{
    public  class ImpuestosRepository : BaseRepository<impuestos>
    {
        public ImpuestosRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
