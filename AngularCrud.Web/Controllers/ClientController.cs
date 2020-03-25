using System;
using System.Threading.Tasks;
using AngularCrud.Application.Services.Client;
using AngularCrud.Data.Entities;
using AngularCrud.WebApp.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace AngularCrud.WebApp.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet, Route("api/Client/")]
        public async Task<IActionResult> GetAsync()
        {
            var clients = await this.clientService.GetAsync();

            return Ok(clients);
        }

        [HttpGet, Route("api/Client/{clientId}")]
        public async Task<IActionResult> GetAsync(Guid clientId)
        {
            var client = await this.clientService.GetAsync(clientId);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPost, Route("api/Client/")]
        public async Task<IActionResult> PostAsync([FromBody]Client client)
        {
            var operationResult = await this.clientService.InsertAsync(client);

            return this.GetActionResult(operationResult);
        }

        [HttpPut, Route("api/Client/")]
        public async Task<IActionResult> PutAsync([FromBody]Client client)
        {
            var operationResult = await this.clientService.UpdateAsync(client);

            return this.GetActionResult(operationResult);
        }

        [HttpDelete, Route("api/Client/{clientId}")]
        public async Task<IActionResult> DeleteAsync(Guid clientId)
        {
            var operationResult = await this.clientService.DeleteAsync(clientId);

            return this.GetActionResult(operationResult);
        }
    }
}
