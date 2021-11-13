#region using directives
using APIRestFul_juan_calderon.Core.Services.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
#endregion

namespace APIRestFul_juan_calderon.API.Extensions
{
	public static class ITransferBuilderExtensionMethod
	{
        #region Constants

        /// <summary>
        /// 
        /// </summary>
        public const string FOLDER = "DataProcess";
        public const string CONECT = "ConnectionClound";

        #endregion
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomizedOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DataProcessOptions>(configuration.GetSection(FOLDER));
            services.Configure<ConnectionOptions>(configuration.GetSection(CONECT));
            return services;
        }

        #endregion
    }
}
