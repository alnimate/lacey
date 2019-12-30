namespace Lacey.Medusa.Common.Core.Serializers
{
    public class NoRootXmlSerializer : WebFormsToXmlSerializer
    {
        public override T Deserialize<T>(string input)
        {
            var root = typeof(T).Name;
            return base.Deserialize<T>($"<{root}>{input}</{root}>");
        }
    }
}