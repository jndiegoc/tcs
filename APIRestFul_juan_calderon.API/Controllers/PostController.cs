#region using directives
using APIRestFul_juan_calderon.Core.Interfaces;
using APIRestFul_juan_calderon.Core.Models;
using APIRestFul_Juan_calderon.Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
#endregion

namespace APIRestFul_juan_calderon.API.Controllers
{
	[ApiController]
    [Route("api/v1/")]
    public class PostController : ControllerBase
	{
        private readonly IPostService _postService;
        private readonly ISecurity _security;

        public PostController(IPostService postService, ISecurity security)
        {
            _postService = postService;
            _security = security;
        }

        /// <summary>
        /// Proceso Post para contar palabras en un texto
        /// </summary>
        /// <param name="dataBody"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("text")]
        public async Task<ResponseWords> PostText([FromBody] DataText dataBody, 
                                                  [FromHeader(Name = "user")][Required] string user, [FromHeader(Name = "password")][Required] string password)
        {
            ResponseWords response = new ResponseWords();
            try
            {
				if (await _security.ConsultSecurity(user, password))
				{
                    if (!string.IsNullOrEmpty(dataBody.Text))
                    {
                        response = await _postService.GetPosts(dataBody);
                    }
                }

                return response;
            }
            catch (Exception)
            {
                return response;
            }
        }
    }
}
