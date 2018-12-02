using Culinary.Data.DbModels;
using Culinary.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Culinary.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
            private readonly ApplicationDbContext _dbContext;
            private readonly DbSet<T> _dbSet;

            public Repository(ApplicationDbContext context)
            {
                _dbContext = context;
                _dbSet = _dbContext.Set<T>();
            }

        public virtual async Task<T> AddAsync(T t)
        {
            _dbSet.Add(t);
            await _dbContext.SaveChangesAsync();
            return t;
        }

        public async Task<bool> AddAsyncBool(T entity)
        {
            await _dbSet.AddAsync(entity);
            return await SaveAsyncBool();
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(Expression<Func<T, bool>> getBy, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.AnyAsync(getBy);
        }

        public virtual T Find(Expression<Func<T, bool>> match)
        {
            return _dbSet.SingleOrDefault(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _dbSet.Where(match).ToList();
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _dbSet.Where(match).ToListAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _dbSet.SingleOrDefaultAsync();
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbSet.Where(predicate);
            return query;
        }

        public virtual async Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<T> FindByAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, bool>> temp)
        {
            return await _dbSet.Where(predicate).SingleOrDefaultAsync();
        }

        public T Get(long id)
        {
            return _dbSet.SingleOrDefault(x => x.Id == id);
        }

        public virtual T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public IQueryable<T> GetAllBy(Expression<Func<T, bool>> getBy, params Expression<Func<T, object>>[] includes)
        {
            return GetAll(includes).Where(getBy);
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = GetAll();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                query = query.Include<T, object>(includeProperty);
            }

            return query;
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetByAsync(Expression<Func<T, bool>> getBy, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(getBy);
        }

        public void Insert(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _dbSet.Remove(entity);
        }

        public async Task<bool> RemoveBool(T entity)
        {
            _dbSet.Remove(entity);
            return await SaveAsyncBool();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public virtual async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> SaveAsyncBool()
        {
            return (await _dbContext.SaveChangesAsync() >= 0);
        }

        public void Update(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _dbContext.SaveChanges();
        }

        public virtual T Update(T t, object key)
        {
            if(t == null)
            {
                return null;
            }
            T exist = _dbSet.Find(key);
            if(exist != null)
            {
                _dbContext.Entry(exist).CurrentValues.SetValues(t);
                _dbContext.SaveChanges();
            }

            return exist;
        }

        public virtual async Task<T> UpdateAsync(T t, object key)
        {
            if(t == null)
            {
                return null;
            }
            T exist = await _dbSet.FindAsync(key);
            if(exist != null)
            {
                _dbContext.Entry(exist).CurrentValues.SetValues(t);
                await _dbContext.SaveChangesAsync();
            }

            return exist;
        }

    }
}
