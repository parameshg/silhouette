using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using System.Threading.Tasks;

namespace Silhouette.Commands
{
    [Command("init")]
    public class Initialize : ICommand
    {
        [CommandOption("name", 'n', Description = "Name of the component, project or solution")]
        public string Name { get; set; } = "Untitled";

        public ValueTask ExecuteAsync(IConsole console)
        {
            console.Output.WriteLine("Initializing...");

            var code = new Codebase(Name);
            var root = Name;
            var project = "Backend";

            // Domain
            {
                code.CreateFolder($@"{root}\{project}.Domain");
                code.CreateFolder($@"{root}\{project}.Domain\Values");
                code.CreateFolder($@"{root}\{project}.Domain\Events");
                code.CreateFolder($@"{root}\{project}.Domain\Entities");
                code.CreateFolder($@"{root}\{project}.Domain\Exceptions");
                code.CreateFolder($@"{root}\{project}.Domain\Enumerations");
                code.Generate<Projects.Domain.Project>($@"{root}\{project}.Domain\{project}.Domain.csproj");
                code.Generate<Projects.Domain.Global>($@"{root}\{project}.Domain\Global.cs");
                code.Generate<Projects.Domain.Entity>($@"{root}\{project}.Domain\Entities\Entity.cs");
                code.Generate<Projects.Domain.Enumeration>($@"{root}\{project}.Domain\Enumerations\Enumeration.cs");
                code.Generate<Projects.Domain.ValueObject>($@"{root}\{project}.Domain\Values\ValueObject.cs");
                code.Generate<Projects.Domain.Event>($@"{root}\{project}.Domain\Events\Event.cs");
                code.Generate<Projects.Domain.Error>($@"{root}\{project}.Domain\Exceptions\Error.cs");
            }

            // Server
            {
                code.CreateFolder($@"{root}\{project}.Server");
                code.CreateFolder($@"{root}\{project}.Server\Queries");
                code.CreateFolder($@"{root}\{project}.Server\Commands");
                code.CreateFolder($@"{root}\{project}.Server\Repositories");
                code.Generate<Projects.Server.Project>($@"{root}\{project}.Server\{project}.Server.csproj");
                code.Generate<Projects.Server.Global>($@"{root}\{project}.Server\Global.cs");
                code.Generate<Projects.Server.AssemblyMarker>($@"{root}\{project}.Server\AssemblyMarker.cs");
            }

            // Database
            {
                code.CreateFolder($@"{root}\{project}.Database");
                code.CreateFolder($@"{root}\{project}.Database\Repositories");
                code.Generate<Projects.Database.Project>($@"{root}\{project}.Database\{project}.Database.csproj");
                code.Generate<Projects.Database.Global>($@"{root}\{project}.Database\Global.cs");
            }

            // Database (FileSystem)
            {
                code.CreateFolder($@"{root}\{project}.Database.FileSystem");
                code.CreateFolder($@"{root}\{project}.Database.FileSystem\Repositories");
                code.Generate<Projects.Database_FileSystem.Project>($@"{root}\{project}.Database.FileSystem\{project}.Database.FileSystem.csproj");
                code.Generate<Projects.Database_FileSystem.Global>($@"{root}\{project}.Database.FileSystem\Global.cs");
            }

            // Api
            {
                code.CreateFolder($@"{root}\{project}.Api");
                code.CreateFolder($@"{root}\{project}.Api\Endpoints");
                code.Generate<Projects.Api.Project>($@"{root}\{project}.Api\{project}.Api.csproj");
                code.Generate<Projects.Api.Global>($@"{root}\{project}.Api\Global.cs");
            }

            // Api (Standalone)
            {
                code.CreateFolder($@"{root}\{project}.Api.Standalone");
                code.CreateFolder($@"{root}\{project}.Api.Standalone\Endpoints");
                code.Generate<Projects.Api_Standalone.Project>($@"{root}\{project}.Api.Standalone\{project}.Api.Standalone.csproj");
                code.Generate<Projects.Api_Standalone.Global>($@"{root}\{project}.Api.Standalone\Global.cs");
                code.Generate<Projects.Api_Standalone.Program>($@"{root}\{project}.Api.Standalone\Program.cs");
                code.Generate<Projects.Api_Standalone.HomeEndpoint>($@"{root}\{project}.Api.Standalone\Endpoints\HomeEndpoint.cs");
            }

            code.Generate<Projects.Solution>($@"{root}\{Name}.sln");

            return default;
        }
    }
}