using Cellar.Application.Cqrs.Command;
using Cellar.Application.Cqrs.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cellar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CellarController : ControllerBase
    {
        private IMediator mediator;
        public CellarController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCellarCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllCellarQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new GetCellarByIdQuery { Id = id }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCellarCommand command)
        {
            command.Id = id;
            return Ok(await mediator.Send(command));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await mediator.Send(new DeleteCellarByIdCommand { Id = id }));
        }

    }
}
