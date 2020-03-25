using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularCrud.Core;
using AngularCrud.Core.Models;
using AngularCrud.Data.Helpers;

namespace AngularCrud.Application.Services.Client
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Data.Entities.Client> repository;

        public ClientService(IRepository<Data.Entities.Client> repository)
        {
            this.repository = repository;
        }

        public async Task<List<Data.Entities.Client>> SearchAsync(string clientName)
        {
            var query = this.repository.GetQueryable();

            if (!string.IsNullOrWhiteSpace(clientName))
            {
                query = query.Where(row => row.Name.Contains(clientName));
            }

            return await query.ToListAsync();
        }

        public async Task<Data.Entities.Client> GetAsync(Guid clientId)
        {
            return await this.repository
                .GetQueryable()
                .FirstOrDefaultAsync(client => client.Id == clientId);
        }

        public async Task<OperationResult> InsertAsync(Data.Entities.Client client)
        {
            var clientValidation = this.ValidateNameAndRole(client);

            if (clientValidation != null)
            {
                return clientValidation;
            }

            return await this.repository.InsertAsync(client);
        }

        public async Task<OperationResult> UpdateAsync(Data.Entities.Client client)
        {
            var clientValidation = this.ValidateId(client)
                                 ?? this.ValidateNameAndRole(client);

            if (clientValidation != null)
            {
                return clientValidation;
            }

            return await this.repository.UpdateAsync(client);
        }

        public async Task<OperationResult> DeleteAsync(Guid clientId)
        {
            var client = await this.GetAsync(clientId);

            if (client == null)
            {
                return new OperationResult(true);
            }

            return await this.repository.DeleteAsync(client);
        }

        private OperationResult ValidateId(Data.Entities.Client client)
        {
            if ((client?.Id ?? Guid.Empty) == Guid.Empty)
            {
                return new OperationResult("The client id is missing.");
            }

            return null;
        }

        private OperationResult ValidateNameAndRole(Data.Entities.Client client)
        {
            if (string.IsNullOrWhiteSpace(client?.Role))
            {
                return new OperationResult("The client name is missing.");
            }

            if (string.IsNullOrWhiteSpace(client.Brand))
            {
                return new OperationResult("The client role is missing.");
            }

            return null;
        }
    }
}
