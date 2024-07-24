using AspireTransit.Consumers.Order;
using MassTransit;


namespace AspireTransit.Consumers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            builder.AddServiceDefaults();

            var connectionString = builder.Configuration.GetConnectionString("eventbus");

            builder.Services.AddMassTransit(x =>
            {
                x.AddConsumer<OrderCreatedConsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(connectionString, h =>
                    {
                        h.Username("username");
                        h.Password("password");
                    });
                    cfg.ConfigureEndpoints(context);
                });
            });

            var host = builder.Build();
            host.Run();
        }
    }
}