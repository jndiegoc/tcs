#region using directives
using Microsoft.WindowsAzure.Storage.Table;
using System;
#endregion

namespace APIRestFul_Juan_calderon.Infraestructure.Queries
{
	public class TableUser : TableEntity
	{
		public TableUser(string user, string password)
		{
			this.PartitionKey = user;
			this.RowKey = password;
		}
		public TableUser() { }
	}
}
