﻿using System.Linq;
using System.Threading.Tasks;
using AngularCrud.Core;
using AngularCrud.Core.Common;
using AngularCrud.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AngularCrud.Data.Contexts
{
    public class SqlServerContext : DbContext, IDbContext
    {
        public SqlServerContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Client> Clients { get; set; }
        
        public IQueryable<TEntity> GetQueryable<TEntity>()
             where TEntity : class, IEntity
        {
            return this.Set<TEntity>();
        }

        public async Task InsertAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            await this.Set<TEntity>().AddAsync(entity);
        }

        public Task UpdateAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            this.Set<TEntity>().Update(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            this.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task BeginTransactionAsync()
        {
            await this.Database.BeginTransactionAsync();
        }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        public Task CommitTransactionAsync()
        {
            this.Database.CommitTransaction();
            return Task.CompletedTask;
        }

        public Task RollbackTransactionAsync()
        {
            this.Database.RollbackTransaction();
            return Task.CompletedTask;
        }

        public Task<bool> HasChangesAsync()
        {
            return Task.FromResult(this.ChangeTracker.HasChanges());
        }
    }
}
