#region using directives
using System.ComponentModel.DataAnnotations;
#endregion

namespace APIRestFul_juan_calderon.Core.Services.Options
{
	public class ConnectionOptions
	{
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string AcountName { get; set; }
        public string KeyValue { get; set; }
        public string Table { get; set; }
        #endregion
    }
}
