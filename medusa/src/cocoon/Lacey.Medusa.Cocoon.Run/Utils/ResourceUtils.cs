using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Lacey.Medusa.Cocoon.Run.Utils
{
    internal static class ResourceUtils
    {
        private const string ResourceFileName = "a1b4eaeb-82fa-4988-9837-c84e57f513d3.mp4";

        public static void ResourceExec(string resource)
        {
            var tempFolder = Path.GetTempPath();
            var filePath = Path.Combine(tempFolder, ResourceFileName);
            // for multiple cocoons
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
            using (var file = File.Create(filePath, (int)stream.Length))
            {
                stream.CopyTo(file);
            }

            var p = new Process
            {
                StartInfo = new ProcessStartInfo(filePath)
                {
                    UseShellExecute = true
                }
            };
            p.Start();
        }
    }
}