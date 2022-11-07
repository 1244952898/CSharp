using System;
using System.Collections.Generic;
using System.Text;

namespace MyIOC_Common_Version2
{
    public class IOCContainerRegistModel
    {
        public Type TargetType { get; set; }

        /// <summary>
        /// 生命周期
        /// </summary>
        public LifetimeTypeEnum Lifetime { get; set; }

        /// <summary>
        /// 仅限单例
        /// </summary>
        public object SingletonInstance { get; set; }
    }
}
