﻿using Culinary.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Culinary.Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);

        Task<T> AddAsync(T t);
        Task<bool> AddAsyncBool(T entity);
        Task<int> DeleteAsync(T entity);
        T Find(Expression<Func<T, bool>> match);
        Task<bool> RemoveBool(T entity);
        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindByAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, bool>> temp);
        IQueryable<T> GetAllBy(Expression<Func<T, bool>> getBy, params Expression<Func<T, object>>[] includes);
        Task<T> GetByAsync(Expression<Func<T, bool>> getBy, params Expression<Func<T, object>>[] includes);
        Task<bool> ExistAsync(Expression<Func<T, bool>> getBy, params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);
        T Get(int id);
        IQueryable<T> GetAll();
        Task<ICollection<T>> GetAllAsync();
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsync(int id);
        void Save();
        Task<int> SaveAsync();
        Task<bool> SaveAsyncBool();
        T Update(T t, object key);
        Task<T> UpdateAsync(T t, object key);

    }
}
