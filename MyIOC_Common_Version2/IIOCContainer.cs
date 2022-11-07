using System;
using System.Collections.Generic;
using System.Text;

namespace MyIOC_Common_Version2
{
    /// <summary>
    /// IOC容器接口
    /// </summary>
    public interface IIOCContainer
    {
        void Register<IFrom,ITo>(string shortName=null, object[] paraList = null, LifetimeTypeEnum lifetimeType = LifetimeTypeEnum.Transient) where ITo : IFrom;
        TFrom Resolve<TFrom>(string shortName = null);
        IIOCContainer CreateChildContainer();
    }
}
