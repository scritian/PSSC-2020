using Orleans;
using System.Threading.Tasks;

namespace GrainInterfaces
{
    public interface IEmailSender : IGrainWithIntegerKey
    {
        Task<string> SendEmailAsync(string message);
    }
}