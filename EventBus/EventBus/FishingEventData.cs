using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus.EventBus
{
    public class FishingEventData: EventData
    {
        public FishType FishType { get; set; }

        public FishingMan FisingMan { get; set; }
    }
}
