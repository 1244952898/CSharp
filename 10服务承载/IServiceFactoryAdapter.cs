﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10服务承载
{
    public interface IServiceFactoryAdapter
    {
        object CreateBuilder(IServiceCollection services);
        IServiceProvider CreateServiceProvider(object containerBuilder);
    }
}
