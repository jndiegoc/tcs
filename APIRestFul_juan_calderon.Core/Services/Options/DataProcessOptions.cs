#region using directives
using System.ComponentModel.DataAnnotations;
#endregion

namespace APIRestFul_juan_calderon.Core.Services.Options
{
	public class DataProcessOptions
	{
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string RegexText { get; set; }
        #endregion
    }
}
