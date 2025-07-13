﻿using System.Linq.Expressions;

namespace CatalogoDeDoces.Repository.Interfaces
{
    public interface IRepositoryGeneric<T> 
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}