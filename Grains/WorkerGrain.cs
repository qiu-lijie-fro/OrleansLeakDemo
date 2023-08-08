using System.Threading.Tasks;
using Grains.Interfaces;
using Microsoft.Extensions.Logging;
using Orleans;

namespace Grains;

public class WorkerGrain : Grain, IWorker
{
    private readonly ILogger<IWorker> _logger;

    public WorkerGrain(ILogger<IWorker> logger)
    {
        _logger = logger;
    }

    public async Task Work()
    {
        var id = this.GetPrimaryKeyString();
        _logger.LogInformation("{id} is working", id);
        await Task.Delay(0);
    }
}
