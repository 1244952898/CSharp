using System.Diagnostics.Tracing;

namespace _5_文件系统
{
    public sealed class PerformanceCounterListener : EventListener
    {
        public static HashSet<string> _keys =
        [
            "Count","Min","Max","Mean","Increment"
        ];
        private static DateTimeOffset? _lastSampleTime;
        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            base.OnEventSourceCreated(eventSource);
            if (eventSource.Name.Equals("System.Runtime"))
            {
                EnableEvents(eventSource, EventLevel.Critical, (EventKeywords)(-1), new Dictionary<string, string> { ["EventCounterIntervalSec"] = "5" });
            }
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            if (_lastSampleTime != null && DateTimeOffset.UtcNow - _lastSampleTime > TimeSpan.FromSeconds(1))
            {
                Console.WriteLine();
            }

            _lastSampleTime = DateTimeOffset.UtcNow;
            var meric=(IDictionary<string,object>)eventData.Payload[0];
            var name = meric["name"];
            var values=meric.Where(it=>_keys.Contains(it.Key)).Select(it=>$"{it.Key} = {it.Value}");
            var timespan= DateTimeOffset.UtcNow.ToString("yyyy-MM-dd hh:mm:ss");
            Console.WriteLine($"[{timespan}]{name,-32}:{string.Join(";",values)}");
        }
    }
}
