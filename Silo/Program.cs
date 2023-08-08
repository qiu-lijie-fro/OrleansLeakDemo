using System;
using Grains;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Hosting;
using OrleansLeakDemo;

IHostBuilder builder = new HostBuilder()
    .UseOrleans(silo =>
    {
        silo.UseLocalhostClustering()
            .ConfigureApplicationParts(parts => parts
                .AddApplicationPart(typeof(ForemanGrain).Assembly)
                .AddApplicationPart(typeof(WorkerGrain).Assembly)
                .WithReferences())
            .ConfigureLogging(logging => logging.AddConsole())
            .AddStartupTask<StartupService>();
    });

using IHost host = builder.Build();

await host.StartAsync();

Console.WriteLine("\n\nPress Enter to terminate...\n\n");
Console.ReadLine();

await host.StopAsync();
