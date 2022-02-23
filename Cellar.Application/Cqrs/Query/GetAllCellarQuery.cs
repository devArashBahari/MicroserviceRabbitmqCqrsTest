

using Cellar.Domain;
using Cellar.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cellar.Application.Cqrs.Query
{
    public class GetAllCellarQuery : IRequest<IEnumerable<CellarEntity>>
    {
        public class GetAllCellarQueryHandler
        {
            private CellarContext context;
            public GetAllCellarQueryHandler(CellarContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<CellarEntity>> Handle(GetAllCellarQuery query, CancellationToken cancellationToken)
            {
                var CellarList = await context.Cellars.ToListAsync();
                return CellarList;
            }
        }
    }
}
