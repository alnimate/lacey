using System.Collections.Generic;

namespace Lacey.Medusa.Common.Generators.Generators
{
    public interface IFirstNamesGenerator
    {
        IReadOnlyList<string> Generate();
    }
}