using Cellar.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellar.Application.Cqrs.Command
{
    public class DeleteCellarByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteCellarByIdCommandHandler : IRequestHandler<DeleteCellarByIdCommand, int>
        {
            private CellarContext context;
            public DeleteCellarByIdCommandHandler(CellarContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(DeleteCellarByIdCommand command, CancellationToken cancellationToken)
            {
                var Cellar = await context.Cellars.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                context.Cellars.Remove(Cellar);
                await context.SaveChangesAsync();
                return Cellar.Id;
            }
        }
    }
}
