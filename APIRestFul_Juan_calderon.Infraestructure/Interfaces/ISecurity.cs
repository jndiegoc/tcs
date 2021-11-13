#region using directives
using APIRestFul_juan_calderon.Core.Models;
using System.Threading.Tasks;
#endregion

namespace APIRestFul_Juan_calderon.Infraestructure.Interfaces
{
	public interface ISecurity
	{
		Task<bool> ConsultSecurity(string user, string password);
	}
}
