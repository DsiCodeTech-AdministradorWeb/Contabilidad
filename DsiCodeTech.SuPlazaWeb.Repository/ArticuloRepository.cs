﻿using DsiCodeTech.SuPlazaWeb.Repository.Infraestructure;
using DsiCodeTech.SuPlazaWeb.Repository.Infraestructure.Contract;
using DsiCodeTech.SuPlazaWeb.Repository.PosContabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodeTech.SuPlazaWeb.Repository
{
    public class ArticuloRepository : BaseRepository<articulo>
    {
        public ArticuloRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}