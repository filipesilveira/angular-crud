using System.Threading.Tasks;
using AngularCrud.Core;
using Microsoft.AspNetCore.Http;

namespace AngularCrud.WebApp.Middlewares
{
    public class TransactionMiddleware
    {
        private RequestDelegate next;

        public TransactionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, IUnitOfWork unitOfWork)
        {
            await this.next.Invoke(context);
            await unitOfWork.CommitAsync();
        }
    }
}
