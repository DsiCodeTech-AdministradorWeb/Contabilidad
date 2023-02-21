using DsiCodeTech.Common.DataAccess.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DsiCodeTech.SuPlazaWeb.Repository.Infraestructure
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        internal DbSet<T> dbSet;

        internal DbContextTransaction dbContextTransaction;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            _unitOfWork = unitOfWork;
            dbSet = _unitOfWork.Db.Set<T>();
        }

        public void startTransaction()
        {
            dbContextTransaction = _unitOfWork.Db.Database.BeginTransaction();
        }

        public void commitTransaction()
        {
            dbContextTransaction.Commit();
        }

        public void rollbackTransaction()
        {
            dbContextTransaction.Rollback();
        }

        public void disposeTransaction()
        {
            dbContextTransaction.Dispose();
        }

        public T SingleOrDefault(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where.Compile()).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where.Compile()).AsEnumerable();
        }

        public virtual T Insert(T entity)
        {
            dynamic val = dbSet.Add(entity);
            _unitOfWork.Db.SaveChanges();
            return val;
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            _unitOfWork.Db.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Db.SaveChanges();
        }

        public virtual void UpdateAll(IList<T> entities)
        {
            foreach (T entity in entities)
            {
                dbSet.Attach(entity);
                _unitOfWork.Db.Entry(entity).State = EntityState.Modified;
            }

            _unitOfWork.Db.SaveChanges();
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> all = GetAll(where);
            foreach (T item in all)
            {
                if (_unitOfWork.Db.Entry(item).State == EntityState.Detached)
                {
                    dbSet.Attach(item);
                }

                dbSet.Remove(item);
            }

            _unitOfWork.Db.SaveChanges();
        }

        public T SingleOrDefaultOrderBy(Expression<Func<T, bool>> whereCondition, Expression<Func<T, int>> orderBy, string direction)
        {
            if (direction == "ASC")
            {
                return dbSet.Where(whereCondition).OrderBy(orderBy).FirstOrDefault();
            }

            return dbSet.Where(whereCondition).OrderByDescending(orderBy).FirstOrDefault();
        }

        public bool Exists(Expression<Func<T, bool>> whereCondition)
        {
            return dbSet.Any(whereCondition);
        }

        public int Count()
        {
            return dbSet.Count();
        }

        public IEnumerable<T> GetPagedRecords(Expression<Func<T, bool>> whereCondition, Expression<Func<T, string>> orderBy, int pageNo, int pageSize)
        {
            return dbSet.Where(whereCondition).OrderBy(orderBy).Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .AsEnumerable();
        }

        public IEnumerable<T> GetPagedRecordsSort(Expression<Func<T, bool>> whereCondition, Expression<Func<T, string>> orderBy, int pageNo, int pageSize, string direction)
        {
            if ("ASC".Equals(direction))
            {
                return dbSet.Where(whereCondition).OrderBy(orderBy).Skip((pageNo - 1) * pageSize)
                    .Take(pageSize)
                    .AsEnumerable();
            }

            return dbSet.Where(whereCondition).OrderByDescending(orderBy).Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .AsEnumerable();
        }

        public IEnumerable<T> ExecWithStoreProcedure(string query, params object[] parameters)
        {
            return dbSet.SqlQuery(query, parameters);
        }

        public IEnumerable<T> GetAllWithPageRecords(Expression<Func<T, string>> orderBy, int pageNo, int pageSize)
        {
            return dbSet.OrderBy(orderBy).Skip((pageNo - 1) * pageSize).Take(pageSize)
                .AsEnumerable();
        }

        public T SingleOrDefaultInclude(Expression<Func<T, bool>> where, string entity)
        {
            return dbSet.Include(entity).Where(where.Compile()).FirstOrDefault();
        }

        public T SingleOrDefaultIncludes(Expression<Func<T, bool>> where, string entity1, string entity2)
        {
            return dbSet.Include(entity1).Include(entity2).Where(where.Compile())
                .FirstOrDefault();
        }

        public T SingleOrDefaultForIncludes(Expression<Func<T, bool>> where, string entity1, string entity2, string entity3, string entity4)
        {
            return dbSet.Include(entity1).Include(entity2).Include(entity3)
                .Include(entity4)
                .Where(where.Compile())
                .FirstOrDefault();
        }

        public IEnumerable<T> GetIncludeAll(Expression<Func<T, bool>> where, string entity)
        {
            return dbSet.Include(entity).Where(where.Compile()).AsEnumerable();
        }

        public IEnumerable<T> GetIncludeForAll(Expression<Func<T, bool>> where, string entity, string entity2, string entity3)
        {
            return dbSet.Include(entity).Include(entity2).Include(entity3)
                .Where(where.Compile())
                .AsEnumerable();
        }

        public IEnumerable<T> GetIncludeForTwo(Expression<Func<T, bool>> where, string entity, string entity2)
        {
            return dbSet.Include(entity).Include(entity2).Where(where.Compile())
                .AsEnumerable();
        }
    }
}
