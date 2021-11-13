#region using directives
using APIRestFul_juan_calderon.Core.Models;
using System.Threading.Tasks;
#endregion

namespace APIRestFul_juan_calderon.Core.Interfaces
{
	public interface IPostService
	{
		Task<ResponseWords> GetPosts(DataText dataText);
	}
}
