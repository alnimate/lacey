// Code from YoutubeExplode (LGPL https://github.com/Tyrrrz/YoutubeExplode/blob/master/License.txt)

using System.Text;

namespace Lacey.Medusa.Youtube.Api.Video.Base.Core.CipherOperations
{
    internal class ReverseCipherOperation : ICipherOperation
    {
        public string Decipher(string input)
        {
            return Reverse(input);
        }
        private string Reverse(string str)
        {
            var sb = new StringBuilder(str.Length);

            for (var i = str.Length - 1; i >= 0; i--)
                sb.Append(str[i]);

            return sb.ToString();
        }
    }
}
