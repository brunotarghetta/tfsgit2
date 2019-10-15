using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using StructureMap.AspNetCore;


namespace BCR.Web.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStructureMap();
                    webBuilder.UseStartup<Startup>();
                });
    }
}
