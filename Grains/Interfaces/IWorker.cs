using System.Threading.Tasks;
using Orleans;

namespace Grains.Interfaces;

public interface IWorker : IGrainWithStringKey
{
    Task Work();
}
