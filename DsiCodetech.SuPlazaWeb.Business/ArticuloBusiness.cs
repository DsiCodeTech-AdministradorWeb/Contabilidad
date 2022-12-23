using DsiCodetech.SuPlazaWeb.Business.Interface;
using DsiCodeTech.SuPlazaWeb.Repository;
using DsiCodeTech.SuPlazaWeb.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.SuPlazaWeb.Business
{
    /// <summary>
    /// clase de negocio que implementa la interfaz de negocio
    /// </summary>
    public class ArticuloBusiness:IArticuloBusiness
    {
        /// <summary>
        /// implementacion de la unidad de trabajo
        /// </summary>
        private readonly IUnitOfWork unitOfWork;
        /// <summary>
        /// Implementacion del repositorio Articulo
        /// </summary>
        private readonly ArticuloRepository repository;
        public ArticuloBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new ArticuloRepository(unitOfWork);
        }
    }
}
