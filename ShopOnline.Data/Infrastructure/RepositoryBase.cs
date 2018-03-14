using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        #region Properties
        private ShopOnLineDBContext DataContext;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected ShopOnLineDBContext DbContext
        {
            get { return DataContext ?? (DataContext = DbFactory.Init()); }
        }
        #endregion

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;

            dbSet = DbContext.Set<T>();
        }
        #region Implementation

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;

        }
        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }
        public virtual void DeleteMulti(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
            {
                dbSet.Remove(obj);
            }
        }
        public virtual T GetSingleByID(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where, string includes)
        {
            return dbSet.Where(where).ToList();
        }

        public virtual int Count(Expression<Func<T, bool>> where)
        {
            return dbSet.Count(where);
        }

        public IQueryable<T> GetAll(string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = DataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                    return query.AsQueryable();
                }
            }
            return DataContext.Set<T>().AsQueryable();
        }
        public T GetSingleByCondition(Expression<Func<T, bool>> Expression, string[] includes = null)
        {

            return GetAll(includes).FirstOrDefault(Expression);
        }

        public virtual IQueryable<T> GetMulti(Expression<Func<T, bool>> Predicate, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = DataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.Where<T>(Predicate).AsQueryable<T>();
            }
            return DataContext.Set<T>().Where<T>(Predicate).AsQueryable<T>();
        }

        public virtual IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            int SkipCount = index * size;
            IQueryable<T> _resetSet;

            if (includes != null && includes.Count() > 0)
            {
                var query = DataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                _resetSet = predicate != null ? query.Where<T>(predicate).AsQueryable() : query.AsQueryable();
            }
            else
            {
                _resetSet = predicate != null ? DataContext.Set<T>().Where<T>(predicate).AsQueryable() : DataContext.Set<T>().AsQueryable();
            }
            _resetSet = SkipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(SkipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public bool CheckContains(Expression<Func<T, bool>> Predicate)
        {
            return DataContext.Set<T>().Count() > 0;
        }
        #endregion
    }
}

