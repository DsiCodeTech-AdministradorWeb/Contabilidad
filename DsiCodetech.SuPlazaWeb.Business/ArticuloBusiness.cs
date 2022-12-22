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
    public class ArticuloBusiness:IArticuloBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ArticuloRepository repository;
        public ArticuloBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new ArticuloRepository(unitOfWork);
        }
    }
}
