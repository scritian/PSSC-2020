using System.Threading.Tasks;

namespace GrainInterfaces
{
    public interface IAsyncHello : Orleans.IGrainWithStringKey
    {
        Task StartAsync();
    }
}
