using CliFx;

namespace Silhouette
{
    public class Program
    {
        public static int Main(string[] args)
        {
            return new CliApplicationBuilder().AddCommandsFromThisAssembly().Build().RunAsync().GetAwaiter().GetResult();
        }
    }
}