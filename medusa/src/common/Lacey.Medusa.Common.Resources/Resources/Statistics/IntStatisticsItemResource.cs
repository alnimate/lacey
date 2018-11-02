namespace Lacey.Medusa.Common.Resources.Resources.Statistics
{
    public class IntStatisticsItemResource : StatisticsItemResource<int>
    {
        public IntStatisticsItemResource()
        {
            
        }

        public IntStatisticsItemResource(string label, int data)
            : base(label, data)
        {
        }
    }
}