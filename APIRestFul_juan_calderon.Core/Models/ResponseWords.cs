#region using directives
using System.Collections.Generic;
#endregion

namespace APIRestFul_juan_calderon.Core.Models
{
	public class ResponseWords
	{
		public string Text { get; set; }
		public IEnumerable<CountWords> CountWords { get; set; }
}
}
