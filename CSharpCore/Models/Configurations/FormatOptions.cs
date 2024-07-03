using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCore.Models.Configurations
{
    public class FormatOptions
    {
        public DateTimeFormatOptions DateTime { get; set; }
        public CurrentDecimalFormatOptions CurrentDecimal { get; set; }

        public FormatOptions()
        {
            
        }

        public FormatOptions(IConfiguration configuration)
        {
            DateTime=new DateTimeFormatOptions(configuration.GetSection("DateTime"));
            CurrentDecimal = new CurrentDecimalFormatOptions(configuration.GetSection("CurrentDecimal"));
        }
    }
}
