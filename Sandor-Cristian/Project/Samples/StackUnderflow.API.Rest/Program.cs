using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace FakeSO.API.Rest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            /*.UseOrleans(siloBuilder =>
            {
                siloBuilder.UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "OrleansBasics";
                })
                .ConfigureApplicationParts(
                    parts => parts.AddApplicationPart(typeof(EmailSenderGrain).Assembly)
                            .WithReferences());
            })*/;
    }
}
