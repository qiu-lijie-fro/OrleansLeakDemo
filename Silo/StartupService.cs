using System.Threading;
using System.Threading.Tasks;
using Grains.Interfaces;
using Orleans;
using Orleans.Runtime;

namespace OrleansLeakDemo;

public class StartupService : IStartupTask
{
    private readonly IGrainFactory _grainFactory;

    public StartupService(IGrainFactory grainFactory)
    {
        _grainFactory = grainFactory;
    }

    public async Task Execute(CancellationToken cancellationToken)
    {
        var foreman = _grainFactory.GetGrain<IForeman>("ForemanGrain");
        await foreman.Start();
    }
}
