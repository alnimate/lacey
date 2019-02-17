using System.Collections.Generic;

namespace Lacey.Medusa.Common.Generators.Generators
{
    public interface INamesGenerator
    {
        IReadOnlyList<string> GenerateFirstNames();

        IReadOnlyList<string> GenerateLastNames();
    }
}