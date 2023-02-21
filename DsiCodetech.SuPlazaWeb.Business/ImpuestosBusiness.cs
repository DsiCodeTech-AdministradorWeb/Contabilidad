using DsiCodetech.SuPlazaWeb.Business.Interface;
using DsiCodeTech.Common.DataAccess.Infraestructure.Contract;
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
    public class ImpuestosBusiness: IImpuestosBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ImpuestosRepository repository;
        public ImpuestosBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new ImpuestosRepository(unitOfWork);
        }

        /// <summary>
        /// Este metodo se encarga de actualizar o insertar una entidad impuesto
        /// </summary>
        /// <param name="impuestoDM">la entidad impuestoDM</param>
        /// <returns>retorno de un valor true/false</returns>
        public bool AddUpdateImpuesto(ImpuestoDM impuestoDM) {
            bool respuesta = false;
            if (impuestoDM != null) 
            {
                impuestos impuesto = repository.SingleOrDefault(p => p.id == impuestoDM.id);
                if (impuestoDM.id > 0)
                {
                    impuesto.cod_barras = impuestoDM.cod_barras;
                    impuesto.descripcion = impuestoDM.descripcion;
                    impuesto.porcentaje = impuestoDM.porcentaje;
                    impuesto.fecha_registro = DateTime.Now;
                    repository.Update(impuesto);
                    respuesta = true;
                }
                else 
                {
                    impuesto = new impuestos();
                    impuesto.cod_barras = impuestoDM.cod_barras;
                    impuesto.descripcion = impuestoDM.descripcion;
                    impuesto.porcentaje = impuestoDM.porcentaje;
                    impuesto.fecha_registro = DateTime.Now;
                    repository.Insert(impuesto);
                    respuesta = true;
                }

            }
            return respuesta;
        }

    }
}
