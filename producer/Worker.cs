using MassTransit;
using Events;

namespace producer;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IPublishEndpoint endpoint;

    public Worker(ILogger<Worker> logger, IPublishEndpoint endpoint)
    {
        _logger = logger;
        this.endpoint = endpoint;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker is publishing at: {time}", DateTimeOffset.Now);

            await endpoint.Publish(new RandomEvent() { Success = true });

            _logger.LogInformation("Worker published at: {time}", DateTimeOffset.Now);

            await Task.Delay(10_000, stoppingToken);
        }
    }
}
