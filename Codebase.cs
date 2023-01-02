using EnsureThat;
using System;
using System.IO;

namespace Silhouette
{
    public class Codebase
    {
        public string Prefix { get; private set; }

        public Codebase(string prefix)
        {
            Prefix = EnsureArg.IsNotNull(prefix);
        }

        public void CreateFolder(string path)
        {
            Directory.CreateDirectory(path);
        }

        public void Generate<T>(string filename)
        {
            Console.WriteLine($"Generating {filename}...");

            dynamic template = Activator.CreateInstance(typeof(T));

            if (template != null)
            {
                template.Session = new Microsoft.VisualStudio.TextTemplating.TextTemplatingSession();
                template.Session["Prefix"] = Prefix;
                template.Initialize();

                File.WriteAllText(filename, template?.TransformText());
            }
        }
    }
}