using AutoMapper.Configuration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCTest.Cat.Models
{
    [MapTo(typeof(IQux),catLifetime:CatLifetime.Root)]
    public class Qux:Base,IQux
    {
    }
}
