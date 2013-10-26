using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Infrastructure.Repository
{
    using System.Data;
    using System.Data.Entity;
    using System.Linq.Expressions;

    using OnionArchitecture.Core.Repository;

    public class EntityFrameworkGenericRepository<T> : IGenericRepository<T>

            where T : class
    {
        protected DbContext Context = null;

        public EntityFrameworkGenericRepository(DbContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            Context = context;
        }
        protected DbSet<T> DbSet
        {
            get
            {
                return Context.Set<T>();
            }
        }

        /// <summary>
        /// Alls the specified includes.
        /// </summary>
        /// <param name="includes">The includes.</param>
        /// <returns></returns>
        public virtual IQueryable<T> All(params string[] includes)
        {
            IQueryable<T> query = DbSet;
            foreach (var child in includes)
            {
                query = query.Include(child);
            }
            return query;
        }

        /// <summary>
        /// Filters the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <returns></returns>
        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            IQueryable<T> query = DbSet;

            foreach (var child in includes)
            {
                query = query.Include(child);
            }
            return query.Where(predicate).AsQueryable<T>();
        }

        /// <summary>
        /// Filters the specified filter.
        /// </summary>
        /// <typeparam name="Key">The type of the ey.</typeparam>
        /// <param name="filter">The filter.</param>
        /// <param name="total">The total.</param>
        /// <param name="index">The index.</param>
        /// <param name="size">The size.</param>
        /// <param name="includes">The includes.</param>
        /// <returns></returns>
        public virtual IQueryable<T> Filter<Key>(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, params string[] includes)
        {
            IQueryable<T> query = DbSet;

            foreach (var child in includes)
            {
                query = query.Include(child);
            }

            int skipCount = index * size;
            var _resetSet = filter != null ? query.Where(filter).AsQueryable() : query.AsQueryable();
            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        /// <summary>
        /// Determines whether [contains] [the specified predicate].
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified predicate]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        /// <summary>
        /// Finds the specified keys.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <returns></returns>
        public virtual T Find(params object[] keys)
        {
            return DbSet.Find(keys);
        }

        /// <summary>
        /// Finds the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <returns></returns>
        public virtual T Find(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            IQueryable<T> query = DbSet;

            foreach (var child in includes)
            {
                query = query.Include(child);
            }

            return query.FirstOrDefault(predicate);
        }


        /// <summary>
        /// Creates the specified T object.
        /// </summary>
        /// <param name="TObject">The T object.</param>
        public virtual void Create(T TObject)
        {
            DbSet.Add(TObject);
        }

        /// <summary>
        /// Counts the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public virtual int Count(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Count(predicate);
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns></returns>
        public virtual int Count()
        {
            return DbSet.Count();
        }

        /// <summary>
        /// Deletes the specified T object.
        /// </summary>
        /// <param name="TObject">The T object.</param>
        public virtual void Delete(T TObject)
        {
            DbSet.Remove(TObject);
        }

        /// <summary>
        /// Updates the specified T object.
        /// </summary>
        /// <param name="TObject">The T object.</param>
        public virtual void Update(T TObject)
        {
            var entry = Context.Entry(TObject);
            DbSet.Attach(TObject);
            entry.State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                DbSet.Remove(obj);
        }
    }
}
