using MediatR;

namespace DemoMediatr.MediatRefactor
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        public Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Core Create User Called");
            return Unit.Task;
        }
    }


    public class CreateUserCommand : IRequest
    { 
    }
}
