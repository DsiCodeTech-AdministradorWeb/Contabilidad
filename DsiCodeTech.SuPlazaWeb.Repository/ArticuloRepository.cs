﻿using DsiCodeTech.Common.DataAccess.Infraestructure.Contract;
using DsiCodeTech.SuPlazaWeb.Repository.Infraestructure;
using DsiCodeTech.SuPlazaWeb.Repository.PosContabilidad;
using LinqKit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DsiCodeTech.SuPlazaWeb.Repository
{
    public class ArticuloRepository : BaseRepository<articulo>, Common.DataAccess.Infraestructure.Contract.IPagingAndSortingRepository<articulo>
    {
        public ArticuloRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public int Count(Expression<Func<articulo, bool>> whereCondition)
        {
            return dbSet.AsExpandable().Count(whereCondition);
        }
        public IEnumerable<articulo> GetPaging(Expression<Func<articulo, string>> orderBy, int page_number, int page_size)
        {
            return dbSet.OrderBy(orderBy).Skip((page_number - 1) * page_size).Take(page_size).AsEnumerable();
        }

        public IEnumerable<articulo> GetPaging(Expression<Func<articulo, bool>> where, Expression<Func<articulo, string>> orderBy, int page_number, int page_size)
        {
            return dbSet.AsExpandable().Where(where).OrderBy(orderBy).Skip((page_number - 1) * page_size).Take(page_size).AsEnumerable();
        }

        public IEnumerable<articulo> GetPagingDescending(Expression<Func<articulo, string>> orderBy, int page_number, int page_size)
        {
            return dbSet.OrderByDescending(orderBy).Skip((page_number - 1) * page_size).Take(page_size).AsEnumerable();
        }

        public IEnumerable<articulo> GetPagingDescending(Expression<Func<articulo, bool>> where, Expression<Func<articulo, string>> orderBy, int page_number, int page_size)
        {
            return dbSet.AsExpandable().Where(where).OrderByDescending(orderBy).Skip((page_number - 1) * page_size).Take(page_size).AsEnumerable();
        }
    }
}
