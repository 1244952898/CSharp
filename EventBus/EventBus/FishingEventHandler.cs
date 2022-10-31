using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus.EventBus
{
    /// <summary>
    /// 钓鱼事件处理
    /// </summary>
    public class FishingEventHandler : IEventHandler<FishingEventData>
    {
        public void HandleEvent(FishingEventData eventData)
        {
            eventData.FisingMan.FishCount++;
            Console.WriteLine("{0}：钓到一条[{2}]，已经钓到{1}条鱼了！",
            eventData.FisingMan.Name, eventData.FisingMan.FishCount, eventData.FishType);
        }
    }
}
