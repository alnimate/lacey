using System.Collections.Generic;
using Lacey.Medusa.Youtube.Scrap.Base.Internal.CipherOperations;

namespace Lacey.Medusa.Youtube.Scrap.Base.Internal
{
    public class PlayerSource
    {
        public IReadOnlyList<ICipherOperation> CipherOperations { get; }

        public PlayerSource(IReadOnlyList<ICipherOperation> cipherOperations)
        {
            CipherOperations = cipherOperations;
        }

        public string Decipher(string input)
        {
            foreach (var operation in CipherOperations)
                input = operation.Decipher(input);
            return input;
        }
    }
}