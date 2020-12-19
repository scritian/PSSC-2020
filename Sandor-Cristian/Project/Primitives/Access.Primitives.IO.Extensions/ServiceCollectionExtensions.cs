using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Linq;
using System.Reflection;

namespace Access.Primitives.IO.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOperations(this IServiceCollection serviceCollection, Assembly assembly)
        {
            serviceCollection.TryAddTransient(typeof(LiveInterpreterAsync));

            var types = assembly.GetTypes()
                .Where(p => typeof(IInterpreter).IsAssignableFrom(p));

            types.ToList().ForEach(p =>
            {
                var markerInterface = p.GetInterfaces().SingleOrDefault(r => typeof(IAdapter).IsAssignableFrom(r) && r.IsGenericType);
                if (markerInterface != null)
                    serviceCollection.TryAddTransient(markerInterface, p);
            });
            return serviceCollection;
        }
    }
}
