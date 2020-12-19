using GrainInterfaces;
using System.Threading.Tasks;

namespace GrainImplementation
{
    public class EmailSenderGrain : Orleans.Grain, IEmailSender
    {
        public Task<string> SendEmailAsync(string message)
        {
            //todo send e-mail

            return Task.FromResult(message);
        }
    }
}