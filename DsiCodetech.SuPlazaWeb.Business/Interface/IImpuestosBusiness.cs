using DsiCodeTech.SuPlazaWeb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.SuPlazaWeb.Business.Interface
{
    public interface IImpuestosBusiness
    {
        /// <summary>
        /// Este metodo se encarga de actualizar o insertar una entidad impuesto
        /// </summary>
        /// <param name="impuestoDM">la entidad impuestoDM</param>
        /// <returns>retorno de un valor true/false</returns>
        bool AddUpdateImpuesto(ImpuestoDM impuestoDM);
    }
}
