using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCore.Models.Logger
{
    public class DatabaseSourceEventListener: EventListener
    {
        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            if (eventSource.Name == "Arrach-Data-SqlClient")
            {
                EnableEvents(eventSource, EventLevel.LogAlways);
            }
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            Console.WriteLine($"Event Id: {eventData.EventId}");
            Console.WriteLine($"Event Name: {eventData.EventName}");
            Console.WriteLine($"Reload");
            var index = 0;
            foreach (var item in eventData.PayloadNames)
            {
                Console.WriteLine($"\t{item}:{eventData.Payload[index++]}");
            }
        }
    }
}
