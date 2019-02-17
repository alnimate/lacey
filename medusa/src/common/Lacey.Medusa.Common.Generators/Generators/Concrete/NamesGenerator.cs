using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Lacey.Medusa.Common.Generators.Generators.Concrete
{
    public sealed class NamesGenerator : INamesGenerator
    {
        private readonly List<string> firstNames = new List<string>();

        private readonly List<string> lastNames = new List<string>();

        public IReadOnlyList<string> GenerateFirstNames()
        {
            if (!this.firstNames.Any())
            {
                var currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var values = File.ReadAllLines(Path.Combine(currentFolder, "firstnames.txt"));
                this.firstNames.AddRange(values);
            }

            return this.firstNames;
        }

        public IReadOnlyList<string> GenerateLastNames()
        {
            if (!this.lastNames.Any())
            {
                var currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var values = File.ReadAllLines(Path.Combine(currentFolder, "lastnames.txt"));
                this.lastNames.AddRange(values);
            }

            return this.lastNames;
        }
    }
}