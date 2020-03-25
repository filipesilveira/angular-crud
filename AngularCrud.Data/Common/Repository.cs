using System;
using System.Linq;
using System.Threading.Tasks;
using AngularCrud.Core;
using AngularCrud.Core.Common;
using AngularCrud.Core.Models;
using AngularCrud.Data.Entities;
using AngularCrud.Data.Helpers;

namespace AngularCrud.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity 
    {
        private readonly IDbContext dbContext;

        public Repository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return this.dbContext.GetQueryable<TEntity>();
        }
        
        public async Task<OperationResult> InsertAsync(TEntity entity)
        {
            if (await this.AlreadyExistsAsync(entity))
            {
                return new OperationResult($"There is already an {nameof(TEntity)} with the same id.");
            }

            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }

            await this.dbContext.InsertAsync(entity);

            return new OperationResult(entity.Id);
        }

        public async Task<OperationResult> UpdateAsync(TEntity entity)
        {
            if (!await this.AlreadyExistsAsync(entity))
            {
                return new OperationResult($"There is no entity with this id on table {nameof(TEntity)}.");
            }

            await this.dbContext.UpdateAsync(entity);

            return new OperationResult(entity.Id);
        }

        public async Task<OperationResult> DeleteAsync(TEntity entity)
        {
            if (!await this.AlreadyExistsAsync(entity))
            {
                return new OperationResult($"There is no entity with this id on table {nameof(TEntity)}.");
            }

            await this.dbContext.DeleteAsync(entity);

            return new OperationResult(entity.Id);
        }

        private async Task<bool> AlreadyExistsAsync(TEntity entity)
        {
            return await this.dbContext.GetQueryable<TEntity>().AnyAsync(x => x.Id == entity.Id);
        }
    }
}
