using System.Threading.Tasks;
using Orleans;

namespace Grains.Interfaces;

public interface IForeman : IGrainWithStringKey
{
    Task Start();
}
