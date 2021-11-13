#region using directives
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
#endregion

namespace APIRestFul_juan_calderon.API
{
	public class Program
	{
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
      WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                //.UseSerilog()
                .UseUrls("http://localhost:5002")
                .ConfigureServices(services => services.AddAutofac());
    }
}
