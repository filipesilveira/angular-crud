using System.Linq;
using System.Threading.Tasks;
using AngularCrud.Core.Models;

namespace AngularCrud.Core
{
    public interface IRepository<TEntity> 
        where TEntity : IEntity
    {
        IQueryable<TEntity> GetQueryable();

        Task<OperationResult> InsertAsync(TEntity entity);
        Task<OperationResult> UpdateAsync(TEntity entity);
        Task<OperationResult> DeleteAsync(TEntity entity);
    }
}
