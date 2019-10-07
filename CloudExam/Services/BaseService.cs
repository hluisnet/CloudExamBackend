using CloudExam.Data;
using CloudExam.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CloudExam.Services
{
    public class BaseService<TEntity, TKey> : IBaseService<TEntity, TKey>
        where TEntity : Entity<TKey>
    {
        protected BaseService(DbContext dbContext)
        {
            this.DbContext = dbContext;
            if (this.DbContext is CloudExamDbContext)
            {
                this.Entities = (this.DbContext as CloudExamDbContext).Set<TEntity>();
            }
        }
        public DbSet<TEntity> Entities { get; }
        public DbContext DbContext { get; }
        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "The given object must not be null");
            }

            await this.Entities.AddAsync(entity);
            return entity;
        }
        public virtual async Task<TEntity> UpdateAsync(TEntity obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "The object must not be null");
            }
            if (!this.Exists(obj.Id))
            {
                throw new ArgumentException("The object does not exist in DB", nameof(obj));
            }
            await Task.Factory.StartNew(() =>
            {
                this.Entities.Update(obj);
            });
            return obj;
        }
        public virtual async Task DeleteAsync(TEntity obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "The object must not be null");
            }

            await Task.Factory.StartNew(() =>
            {
                Entities.Remove(obj);
            });
        }
        public virtual async Task DeleteAsync(TKey id)
        {
            var objToDelete = await this.Entities.FirstOrDefaultAsync(ent => ent.Id.Equals(id));

            if (objToDelete == null)
            {
                throw new ArgumentException("Does not exist an element with the given key", nameof(id));
            }

            this.Entities.Remove(objToDelete);
        }
        public virtual async Task<TEntity> FindAsync(TKey id)
        {
            return await this.Entities.SingleOrDefaultAsync(ent => ent.Id.Equals(id));
        }
        public virtual async Task<bool> ExistsAsync(TKey id)
        {
            return await this.Entities.AnyAsync(ent => ent.Id.Equals(id));
        }
        public virtual bool Exists(TKey id)
        {
            return this.Entities.Any(ent => ent.Id.Equals(id));
        }
        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await this.Entities.ToListAsync();
        }
        public virtual async Task<IQueryable<TEntity>> GetAllAsync(Func<TEntity, bool> filter)
        {
            return await Task.Factory.StartNew(() =>
            {
                return this.Entities.Where(ent => filter.Invoke(ent));
            });
        }
        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await this.DbContext.SaveChangesAsync();
            }
            catch (DbUpdateException dbuEx)
            {
                throw dbuEx;
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
