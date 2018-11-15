namespace Lacey.Medusa.Youtube.Scrap.Base.Internal.CipherOperations
{
    public class ReverseCipherOperation : ICipherOperation
    {
        public string Decipher(string input)
        {
            return input.Reverse();
        }
    }
}