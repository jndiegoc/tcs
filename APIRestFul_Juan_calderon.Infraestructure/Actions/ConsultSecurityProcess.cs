#region using directives
using APIRestFul_juan_calderon.Core.Services.Options;
using APIRestFul_Juan_calderon.Infraestructure.Queries;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace APIRestFul_Juan_calderon.Infraestructure.Actions
{
	public class ConsultSecurityProcess
	{
        /// <summary>
        /// Proceso para consultar las credenciales del API
        /// </summary>
        /// <param name="table"></param>
        /// <param name="acountName"></param>
        /// <param name="keyValue"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> GetSecurity(string table, string acountName, string keyValue, string user, string password)
        {
            try
            {
                return await DoConsult(table, acountName, keyValue, user, password);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Consulta los datos del proceso de seguridad
        /// </summary>
        /// <param name="table"></param>
        /// <param name="acountName"></param>
        /// <param name="keyValue"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private async Task<bool> DoConsult(string table, string acountName, string keyValue, string user, string password)
        {
            bool security = false;
            try
            {
                List<string> dataArchivos = new List<string>();
                var acc = ConnectionCloudOptions.Conec_connectionClound(acountName, keyValue);
                var tableClient = acc.CreateCloudTableClient();
                var tableUser = tableClient.GetTableReference(table);

                TableQuery<TableUser> treanslationsQuery = new TableQuery<TableUser>()
                   .Where(
                    TableQuery.CombineFilters(
                         TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, user)
                     , TableOperators.And,
                         TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, password)
                    )
                 );

                var resultsContactos = await ExecuteQueryOptions.ExecuteQueryAsync<TableUser>(tableUser, treanslationsQuery);
                var datosResult = resultsContactos.Cast<TableUser>();
                if (datosResult.Any())
                {
                    security = true;
                }

                return security;
            }
            catch (Exception)
            {
                return security;
            }
        }
    }
}
