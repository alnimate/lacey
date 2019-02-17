using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Lacey.Medusa.Common.Generators.Generators.Concrete
{
    public sealed class FirstNamesGenerator : IFirstNamesGenerator
    {
        private readonly List<string> values = new List<string>();

        public IReadOnlyList<string> Generate()
        {
            if (!this.values.Any())
            {
                var currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var names = File.ReadAllLines(Path.Combine(currentFolder, "names.txt"));
                this.values.AddRange(names);
            }

            return this.values;
        }
    }
}