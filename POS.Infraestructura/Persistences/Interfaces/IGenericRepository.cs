﻿using POS.Domain.Entities;
using POS.Infrastructure.Commons.Bases.Request;
using System.Linq.Expressions;

namespace POS.Infrastructure.Persistences.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> RegisterAsync(T entity);
        Task<bool> EditAsync(T entity);
        Task<bool> DeleteAsync(int id);

        IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter =  null);

        IQueryable<TDto> Ordering<TDto>(BasePaginationRequest request, IQueryable<TDto> queryable, bool pagination = false) where TDto : class;
    }
}
