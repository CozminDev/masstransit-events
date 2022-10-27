using consumer;
using MassTransit;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMassTransit(busConfig =>
        {
            busConfig.AddConsumer<RandomEventConsumer>();

            busConfig.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(Environment.GetEnvironmentVariable("RABBIT"), h => {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ConfigureEndpoints(context);
            });
        });
    })
    .Build();

await host.RunAsync();