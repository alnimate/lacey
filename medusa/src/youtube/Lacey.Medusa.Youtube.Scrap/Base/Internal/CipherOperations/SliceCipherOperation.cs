namespace Lacey.Medusa.Youtube.Scrap.Base.Internal.CipherOperations
{
    public class SliceCipherOperation : ICipherOperation
    {
        private readonly int _index;

        public SliceCipherOperation(int index)
        {
            _index = index;
        }

        public string Decipher(string input)
        {
            return input.Substring(_index);
        }
    }
}