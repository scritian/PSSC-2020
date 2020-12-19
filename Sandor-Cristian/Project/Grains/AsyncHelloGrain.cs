using GrainInterfaces;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Streams;
using System;
using System.Threading.Tasks;

namespace Grains
{
    public class AsyncHelloGrain : Orleans.Grain, IAsyncHello, IAsyncObserver<string>
    {
        private readonly ILogger logger;

        public AsyncHelloGrain(ILogger<HelloGrain> logger)
        {
            this.logger = logger;
        }

        public async override Task OnActivateAsync()
        {
            IAsyncStream<string> stream = this.GetStreamProvider("SMSProvider").GetStream<string>(Guid.Empty, "email");
            await stream.SubscribeAsync(this);
        }

        public Task OnCompletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task OnErrorAsync(Exception ex)
        {
            throw new NotImplementedException();
        }

        public async Task OnNextAsync(string item, StreamSequenceToken token = null)
        {
            Console.WriteLine($"Email sent to: {this.GetPrimaryKeyString()} - {item}");
        }

        public Task StartAsync()
        {
            return Task.CompletedTask;
        }
    }
}
