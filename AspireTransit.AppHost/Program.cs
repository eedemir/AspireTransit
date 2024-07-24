using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var eventbus = builder.AddRabbitMQ("eventbus")
    .WithManagementPlugin()
    .WithEnvironment("RABBITMQ_DEFAULT_USER", "username")
    .WithEnvironment("RABBITMQ_DEFAULT_PASS", "password");

builder.AddProject<AspireTransit_Consumers>("consumers")
    .WithReference(eventbus);

builder.AddProject<AspireTransit_WebAPI>("webapi")
    .WithReference(eventbus);

builder.Build().Run();