using System.Threading.Tasks;

namespace AngularCrud.Core
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}