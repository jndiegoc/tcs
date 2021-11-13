#region using directives
using APIRestFul_juan_calderon.Core.Interfaces;
using APIRestFul_juan_calderon.Core.Models;
using APIRestFul_juan_calderon.Core.Services.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace APIRestFul_juan_calderon.Core.Services
{
	public class PostService : IPostService
	{
		#region Members
		private readonly IOptions<DataProcessOptions> _dataOptions;
		#endregion


		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="processingOptions"></param>
		/// <param name="consultData"></param>
		public PostService(IOptions<DataProcessOptions> dataOptions)
		{
			_dataOptions = dataOptions;
		}
		#endregion

		/// <summary>
		/// Realiza proceso de verificación del texto
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public async Task<ResponseWords> GetPosts(DataText dataText)
		{
			ResponseWords result = new ResponseWords();
			try
			{
				string formatText = await new ExtensionOptions().ValidateText(_dataOptions.Value.RegexText, dataText.Text);

				if (!string.IsNullOrEmpty(formatText))
				{
					result = await GetCountText(formatText);
				}

				return result;
			}
			catch (Exception)
			{
				return result;
			}
		}

		/// <summary>
		/// Genera resultado de la cantidad de palabras del texto
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		private async Task<ResponseWords> GetCountText(string text)
		{
			ResponseWords result = new ResponseWords();
			try
			{
				IEnumerable<string> words = await GenerateListData(text.ToUpper());

				IEnumerable<CountWords> resultWords = words
					.GroupBy(x => x)
					.Select(group => new CountWords { Word = group.Key, Count = group.Count() }).OrderByDescending(x => x.Count)
					.ToList();

				result = new ResponseWords { Text = text, CountWords  = resultWords };

				return result;
			}
			catch (Exception)
			{
				return result;
			}

		}

		/// <summary>
		/// Genera una lista de las palabras incluidas en el texto
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		private async Task<IEnumerable<string>> GenerateListData(string text)
		{
			IEnumerable<string> listWords = new List<string>();
			try
			{
				listWords = text.Split(' ').Where(st => !st.Equals(""));

				return listWords;
			}
			catch (Exception)
			{
				return listWords;
			}
		}
	}
}
