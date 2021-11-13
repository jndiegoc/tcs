#region using directives
using APIRestFul_juan_calderon.Core.Services.Options;
using APIRestFul_Juan_calderon.Infraestructure.Actions;
using APIRestFul_Juan_calderon.Infraestructure.Interfaces;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
#endregion

namespace APIRestFul_Juan_calderon.Infraestructure.Services
{
	public class Security : ISecurity
	{
		#region Members
		private readonly IOptions<ConnectionOptions> _dataConnect;
		#endregion


		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="processingOptions"></param>
		/// <param name="consultData"></param>
		public Security(IOptions<ConnectionOptions> dataConnect)
		{
			_dataConnect = dataConnect;
		}
		#endregion

		/// <summary>
		/// Proceso para verificar los datos de seguridad
		/// </summary>
		/// <param name="user"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public async Task<bool> ConsultSecurity(string user, string password)
		{
			bool processSecurity = false;
			try
			{
				processSecurity = await new ConsultSecurityProcess().GetSecurity(_dataConnect.Value.Table, _dataConnect.Value.AcountName, _dataConnect.Value.KeyValue, user, password);

				return processSecurity;
			}
			catch (System.Exception)
			{
				return processSecurity;
			}
		}
	}
}
