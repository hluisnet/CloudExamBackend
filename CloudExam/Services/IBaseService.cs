using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudExam.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudExam.Services
{
    public interface IBaseService<TEntity, TKey> where TEntity : Entity<TKey>
    {
        DbSet<TEntity> Entities { get; }
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(TKey id);
        Task<TEntity> FindAsync(TKey id);
        Task<bool> ExistsAsync(TKey id);
        bool Exists(TKey id);
        Task<List<TEntity>> GetAllAsync();
        Task<IQueryable<TEntity>> GetAllAsync(Func<TEntity, bool> filter);

    }
}
