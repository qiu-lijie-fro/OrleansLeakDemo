using System.Collections.Generic;
using System.Threading.Tasks;
using Grains.Interfaces;
using Microsoft.Extensions.Logging;
using Orleans;

namespace Grains;

public class ForemanGrain : Grain, IForeman
{
    private readonly ILogger<IForeman> _logger;
    private readonly IGrainFactory _grainFactory;

    public ForemanGrain(ILogger<IForeman> logger, IGrainFactory grainFactory)
    {
        _logger = logger;
        _grainFactory = grainFactory;
    }

    public Task Start()
    {
        _logger.LogInformation("Foreman is started");
        StartWorker();
        return Task.CompletedTask;
    }

    private async Task StartWorker()
    {
        while (true)
        {
            var tasks = new List<Task>();
            for (var i = 0; i < 500; i++)
                tasks.Add(_grainFactory.GetGrain<IWorker>($"WorkerGrain_{i}").Work());

            await Task.WhenAll(tasks.ToArray());
        }
    }
}
