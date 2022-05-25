using MediatR;

namespace DemoMediatr.MediatRefactor.Decorators
{
    public class MediatrDecorator2 : IMediator
    {
        private readonly IMediator _mediator;

        public MediatrDecorator2(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Publish(object notification, CancellationToken cancellationToken = default)
        {
            Console.WriteLine(nameof(MediatrDecorator2));
            await _mediator.Publish(notification, cancellationToken);
            Console.WriteLine(nameof(MediatrDecorator2));
        }

        public async Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
        {
            Console.WriteLine(nameof(MediatrDecorator2));
            await _mediator.Publish(notification, cancellationToken);
            Console.WriteLine(nameof(MediatrDecorator2));
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            Console.WriteLine(nameof(MediatrDecorator2));
            var response = await _mediator.Send(request, cancellationToken);
            Console.WriteLine(nameof(MediatrDecorator2));
            return response;
        }

        public async Task<object?> Send(object request, CancellationToken cancellationToken = default)
        {
            Console.WriteLine(nameof(MediatrDecorator2));
            var response = await _mediator.Send(request, cancellationToken);
            Console.WriteLine(nameof(MediatrDecorator2));
            return response;
        }
    }
}
