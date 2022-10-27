using Events;
using MassTransit;

namespace consumer
{
    internal class RandomEventConsumer : IConsumer<RandomEvent>
    {
        private readonly ILogger<RandomEventConsumer> _logger;

        public RandomEventConsumer(ILogger<RandomEventConsumer> logger)
        {
            _logger = logger;
        }


        public Task Consume(ConsumeContext<RandomEvent> context)
        {
            _logger.LogInformation("Random event success is: {time}", context.Message.Success);

            return Task.CompletedTask;
        }
    }
}
