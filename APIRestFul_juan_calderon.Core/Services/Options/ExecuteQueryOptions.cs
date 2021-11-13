#region using directives
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
#endregion

namespace APIRestFul_juan_calderon.Core.Services.Options
{
    public static class ExecuteQueryOptions
    {
        public static async Task<ICollection<T>> ExecuteQueryAsync<T>(this CloudTable table, TableQuery<T> query) where T : ITableEntity, new()
        {
            var items = new List<T>();
            try
            {
                TableContinuationToken token = null;

                do
                {
                    TableQuerySegment<T> seg = await table.ExecuteQuerySegmentedAsync<T>(query, token);
                    token = seg.ContinuationToken;
                    items.AddRange(seg);
                } while (token != null);
                return items;
            }
            catch (Exception)
            {
                return items;
            }
        }

    }
}
