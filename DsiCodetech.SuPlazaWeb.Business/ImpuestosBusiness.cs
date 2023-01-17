using DsiCodeTech.SuPlazaWeb.Domain;
using DsiCodeTech.SuPlazaWeb.Repository;
using DsiCodeTech.SuPlazaWeb.Repository.Infraestructure.Contract;
using DsiCodeTech.SuPlazaWeb.Repository.PosContabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.SuPlazaWeb.Business
{
    public class ImpuestosBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ImpuestosRepository repository;
        public ImpuestosBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new ImpuestosRepository(unitOfWork);
        }

        public bool AddUpdateImpuesto(ImpuestoDM impuestoDM) {
            bool respuesta = false;
            if (impuestoDM != null) 
            {
                impuestos impuesto = repository.SingleOrDefault(p => p.id == impuestoDM.id);
                if (impuestoDM.id > 0)
                {
                    impuesto.cod_barras = impuestoDM.cod_barras;
                    impuesto.descripcion = impuestoDM.des
                }
            }
        }

    }
}
