#region using directives
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
#endregion

namespace APIRestFul_juan_calderon.Core.Services.Options
{
    public class ExtensionOptions
	{
        public async Task<string> ValidateText(string regex, string text)
        {
            string dataResult = string.Empty;
            try
            {
                Regex rgx_ExpresionReg = new Regex(@regex);

                dataResult = rgx_ExpresionReg.Replace(text, "");

                return dataResult;
            }
            catch (Exception ex)
            {
                return dataResult;
            }
        }
    }
}
