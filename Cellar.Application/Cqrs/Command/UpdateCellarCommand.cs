using Cellar.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellar.Application.Cqrs.Command
{
    public class UpdateCellarCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int Count { get; set; }

        public class UpdateCellarCommandHandler : IRequestHandler<UpdateCellarCommand, int>
        {
            private CellarContext context;
            public UpdateCellarCommandHandler(CellarContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(UpdateCellarCommand command, CancellationToken cancellationToken)
            {
                var Cellar = context.Cellars.Where(a => a.Id == command.Id).FirstOrDefault();

                if (Cellar == null)
                {
                    return default;
                }
                else
                {
                    Cellar.product = command.Product;
                    Cellar.Count = command.Count;
                    await context.SaveChangesAsync();
                    return Cellar.Id;
                }
            }
        }
    }
}
