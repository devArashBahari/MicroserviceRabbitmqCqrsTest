using Cellar.Domain;
using Cellar.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellar.Application.Cqrs.Command
{
    public class CreateCellarCommand : IRequest<int>
    {
        public string product { get; set; }
        public int Count { get; set; }

        public class CreateCellarCommandHandler : IRequestHandler<CreateCellarCommand, int>
        {
            private CellarContext context;
            public CreateCellarCommandHandler(CellarContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(CreateCellarCommand command, CancellationToken cancellationToken)
            {
                var Cellar = new CellarEntity();
                Cellar.product = command.product;
                Cellar.Count = command.Count;

                context.Cellars.Add(Cellar);
                await context.SaveChangesAsync();
                return Cellar.Id;
            }
        }
    }
}
