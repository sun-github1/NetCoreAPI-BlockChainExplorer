using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace BlockchainExplorer.Application.Behaviors
{
    public class LoggingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : notnull
    {
        private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

        public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Starting request: {request.GetType().Name}");

            var response = await next();

            _logger.LogInformation($"Completed request: {request.GetType().Name}");

            return response;
        }
    }
}
