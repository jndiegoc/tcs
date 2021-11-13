#region using directives
using APIRestFul_juan_calderon.Core.Interfaces;
using APIRestFul_juan_calderon.Core.Services;
using APIRestFul_juan_calderon.Core.Services.Options;
using APIRestFul_Juan_calderon.Infraestructure.Interfaces;
using APIRestFul_Juan_calderon.Infraestructure.Services;
using Autofac;
using Microsoft.Extensions.Options;
#endregion

namespace APIRestFul_juan_calderon.API
{
	public class AutofacModule : Module
	{
        /// <summary>
        /// 
        /// </summary>
		public AutofacModule()
		{
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new PostService(c.Resolve<IOptions<DataProcessOptions>>()))
              .As<IPostService>()
              .InstancePerLifetimeScope();

            builder.Register(c => new Security(c.Resolve<IOptions<ConnectionOptions>>()))
              .As<ISecurity>()
              .InstancePerLifetimeScope();
        }
    }
}
