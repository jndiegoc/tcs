#region using directives
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using System;
#endregion


namespace APIRestFul_juan_calderon.Core.Services.Options
{
    public class ConnectionCloudOptions
    {
        /// <summary>
        /// Connection para las table
        /// </summary>
        /// <returns></returns>
        public static CloudStorageAccount Conec_connectionClound(string acountName, string keyValue)
        {
            return new CloudStorageAccount(
                            new StorageCredentials(acountName, keyValue), false);
        }
    }
}
