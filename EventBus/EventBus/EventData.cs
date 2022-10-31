using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus.EventBus
{
    [Serializable]
    public abstract class EventData : IEventData
    {
        public DateTime EventTime { get; set; }

        public object EventSource { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        protected EventData()
        {
            EventTime = DateTime.Now;
        }
    }
}
