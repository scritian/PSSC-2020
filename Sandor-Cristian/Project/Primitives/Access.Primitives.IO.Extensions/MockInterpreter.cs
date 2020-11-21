using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Access.Primitives.IO.Mocking;
using Microsoft.Extensions.DependencyInjection;

namespace Access.Primitives.IO
{ 
    public class MockInterpreterAsync
    {
        private readonly Type _nonGenericTypeMaker = typeof(IAdapter);
        public MockContext MockContext { get; }
        private readonly IServiceProvider _serviceProvider;

        public MockInterpreterAsync(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<A> Interpret<A, S>(Port<A> ma, S state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (var mockContext =
                    (MockContext)scope.ServiceProvider.GetService<IExecutionContext>())
                {
                    return ma is Return<A> r
                        ? r.Value
                        : await ResolveInterpreter<A, S>(scope.ServiceProvider, ma).Mock(mockContext, ma, state, (a) => Interpret(a, state));
                }
            }
        }

        private IInterpreter<S> ResolveInterpreter<A, S>(IServiceProvider sp, Port<A> ma)
        {
            return (IInterpreter<S>)sp.GetService(GetTypeMarker(ma));
        }

        private Type GetTypeMarker<A>(Port<A> ma) =>
            ma.GetType().GetInterfaces().Single(p => _nonGenericTypeMaker.IsAssignableFrom(p) && p.IsGenericType);
    }
}
