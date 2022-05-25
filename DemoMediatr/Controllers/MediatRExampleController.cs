using DemoMediatr.MediatRefactor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DemoMediatr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MediatRExampleController : ControllerBase
    {
        private readonly IMediator mediator;

        public MediatRExampleController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task CreateUser()
        {
            await mediator.Send(new CreateUserCommand() { });
        }
    }
}
