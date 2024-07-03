using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCore.Models.Configurations
{
    public class CurrentDecimalFormatOptions
    {
        public int Digits { get; set; }
        public string Symbol { get; set; }

        public CurrentDecimalFormatOptions()
        {
            
        }

        public CurrentDecimalFormatOptions(IConfiguration configuration)
        {
            Digits = int.Parse(configuration["Digits"]);
            Symbol = configuration["Symbol"];
        }
    }
}
