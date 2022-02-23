using Cellar.Domain;
using Cellar.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellar.Application.Cqrs.Query
{
    public class GetCellarByIdQuery : IRequest<CellarEntity>
    {
        public int Id { get; set; }
        public class GetCellarByIdQueryHandler : IRequestHandler<GetCellarByIdQuery, CellarEntity>
        {
            private CellarContext context;
            public GetCellarByIdQueryHandler(CellarContext context)
            {
                this.context = context;
            }
            public async Task<CellarEntity> Handle(GetCellarByIdQuery query, CancellationToken cancellationToken)
            {
                var Cellar = await context.Cellars.FirstOrDefaultAsync(a => a.Id == query.Id);
                return Cellar;
            }
        }
    }
}
