using Remote.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public static class RemoteRepositoryExtensions
{
    public static Task<List<T>> EvalAsync<T>(this IQueryable<T> source) => AsyncEnumerableExtensions.ToListAsync(source);
}
