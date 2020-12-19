using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Access.Primitives.EFCore
{
    public static class GrainLoader
    {
        public static async Task<T> LoadAsync<TContext, T>(
            this TContext dbContext,
            string spName,
            object parameters,
            Func<SqlMapper.GridReader, Task<T>> callback) where TContext : DbContext
        {
            using (var multi =
                await dbContext.Database.GetDbConnection().QueryMultipleAsync(spName, parameters,
                    commandType: CommandType.StoredProcedure))
            {
                return await callback(multi);
            }
        }
    }
}
