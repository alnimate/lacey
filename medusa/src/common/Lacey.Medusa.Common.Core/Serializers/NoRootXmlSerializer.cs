namespace Lacey.Medusa.Common.Core.Serializers
{
    public class NoRootXmlSerializer : WebFormsToXmlSerializer
    {
        public override T Deserialize<T>(string input)
        {
            var root = typeof(T).Name;
            var xml = $"<{root}>{input}</{root}>"
                .Replace("&", "&amp;");

            return base.Deserialize<T>(xml);
        }
    }
}