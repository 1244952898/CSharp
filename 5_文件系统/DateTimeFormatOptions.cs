using Microsoft.Extensions.Configuration;

namespace _5_文件系统
{
    public class DateTimeFormatOptions
    {
        public DateTimeFormatOptions()
        {
                
        }

        public DateTimeFormatOptions(IConfiguration configuration)
        {
            LongDatePattern = configuration["LongDatePattern"];
            LongTimePattern = configuration["LongTimePattern"];
            ShortDatePattern = configuration["ShortDatePattern"];
            ShortTimePattern = configuration["ShortTimePattern"];
        }

        public string LongDatePattern { get; set; }
        public string LongTimePattern { get; set; }

        public string ShortDatePattern { get; set; }
        public string ShortTimePattern { get; set; }
    }
}
