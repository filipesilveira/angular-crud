using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AngularCrud.Core.Common;
using AngularCrud.Core.Models;

namespace AngularCrud.Application.Services.Client
{
    public interface IClientService : IService
    {
        Task<List<Data.Entities.Client>> GetAsync();
        Task<Data.Entities.Client> GetAsync(Guid clientId);
        Task<OperationResult> InsertAsync(Data.Entities.Client client);
        Task<OperationResult> UpdateAsync(Data.Entities.Client client);
        Task<OperationResult> DeleteAsync(Guid clientId);
    }
}
