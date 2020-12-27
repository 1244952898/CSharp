using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharp
{
    public static class testt
    {
        public static string GetHidenPhoneContent(string content, string keyword = "")
        {

            var needReplaceReg = new Regex("^[0-9]{0,11}$");
            if (!string.IsNullOrWhiteSpace(content))
            {
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    keyword = keyword.Trim();
                    string[] keywords = keyword.Split(' ');
                    if (keywords?.Any() ?? false)
                    {
                        for (int i = 0; i < keywords.Length; i++)
                        {
                            if (needReplaceReg.IsMatch(keywords[i]) && !string.IsNullOrWhiteSpace(keywords[i]))
                            {
                                content = content.Replace($"<em>{keywords[i]}</em>", keywords[i]);
                            }
                        }
                    }
                }

                content = Regex.Replace(content, "((?<!\\d)1\\d{2}[\\s|-]?)\\d{4}([\\s|-]?\\d{4}(?!\\d))", "$1****$2");

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    keyword = keyword.Trim();
                    string[] keywords = keyword.Split(' ');
                    if (keywords?.Any() ?? false)
                    {
                        for (int i = 0; i < keywords.Length; i++)
                        {
                            if (needReplaceReg.IsMatch(keywords[i]) && !string.IsNullOrWhiteSpace(keywords[i]))
                            {
                                content = content.Replace(keywords[i], $"<em>{keywords[i]}</em>");
                            }

                        }
                    }
                }
                //content = Regex.Replace(content, "(1\\d{2})\\d{4}(\\d{4})", "$1****$2");
                //Regex.Replace(content, @"(^1\\d{10}$)", "$1 ****$2");
                //Regex reMobile = new Regex(@"(^1\\d{10}$)");
                //MatchCollection matchCollection = reMobile.Matches(content);
                //if (matchCollection != null && matchCollection.Count > 0)
                //{
                //    for (int i = 0; i < matchCollection.Count; i++)
                //    {
                //        var phone = matchCollection[i].Value;
                //        var newphone = Regex.Replace(content, @"(^1\\d{10}$)", "$1 ****$2");
                //        content = content.Replace(phone, newphone);
                //    }
                //}
            }
            return content;
        }
    }
}
