using AngleSharp.Dom;

namespace Lacey.Medusa.Youtube.Services.Transfer.Utils
{
    internal static class AngleSharpExtensions
    {
        public static string GetText(this IElement node)
        {
            var text = node.Text();
            return text?.Replace("\n", string.Empty).Trim();
        }
    }
}