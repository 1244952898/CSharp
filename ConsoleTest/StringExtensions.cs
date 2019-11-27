using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public static class StringExtensions
    {
        public static string SubStringUnicode(this string str, int length)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;
            if (length < 0)
                throw new ArgumentOutOfRangeException();
            if (length == 0) return string.Empty;
            var chars = System.Text.Encoding.UTF8.GetChars(System.Text.Encoding.UTF8.GetBytes(str));
            int index = 0;
            var charArray = new List<char[]>();
            while (index < chars.Length)
            {
                if (Char.IsHighSurrogate(chars[index]))
                {
                    if ((index + 1) <= chars.Length && char.IsLowSurrogate(chars[index + 1]))
                    {
                        charArray.Add(new char[] { chars[index], chars[index + 1] });
                        index = index + 2;
                    }
                }
                else
                {
                    charArray.Add(new char[] { chars[index] });
                    index++;
                }
            }
            var takeLen = length > charArray.Count ? charArray.Count : length;
            var subChars = charArray.Take(takeLen);
            var resChars = new List<char> { };
            foreach (var item in subChars)
            {
                resChars.AddRange(item);
            }
            return new string(resChars.ToArray());


        }

        public static string SubStringUnicode(this string str, int startIndex, int length)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;
            if (startIndex < 0 || str.Length < startIndex || length < 0)
                throw new ArgumentOutOfRangeException();
            if (length == 0) return string.Empty;

            var chars = Encoding.UTF8.GetChars(Encoding.UTF8.GetBytes(str));
            int index = 0;
            var charArray = new List<char[]>();
            while (index < chars.Length)
            {
                if (Char.IsHighSurrogate(chars[index]))
                {
                    if ((index + 1) <= chars.Length && char.IsLowSurrogate(chars[index + 1]))
                    {
                        charArray.Add(new char[] { chars[index], chars[index + 1] });
                        index = index + 2;
                    }
                }
                else
                {
                    charArray.Add(new char[] { chars[index] });
                    index++;
                }
            }

            var takeLen = length+ startIndex  > charArray.Count ? charArray.Count : length;
            if (startIndex > charArray.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            var subChars = charArray.Skip(startIndex).Take(takeLen);
            var resChars = new List<char> { };
            foreach (var item in subChars)
            {
                resChars.AddRange(item);
            }
            return new string(resChars.ToArray());
        }

        public static string SubStringStartIndexUnicode(this string str, int startIndex)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;
            if (startIndex < 0 || str.Length < startIndex)
                throw new ArgumentOutOfRangeException();

            var chars = Encoding.UTF8.GetChars(Encoding.UTF8.GetBytes(str));
            int index = 0;
            var charArray = new List<char[]>();
            while (index < chars.Length)
            {
                if (Char.IsHighSurrogate(chars[index]))
                {
                    if ((index + 1) <= chars.Length && char.IsLowSurrogate(chars[index + 1]))
                    {
                        charArray.Add(new char[] { chars[index], chars[index + 1] });
                        index = index + 2;
                    }
                }
                else
                {
                    charArray.Add(new char[] { chars[index] });
                    index++;
                }
            }
            if (startIndex > charArray.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            var subChars = charArray.Skip(startIndex);
            var resChars = new List<char> { };
            foreach (var item in subChars)
            {
                resChars.AddRange(item);
            }
            return new string(resChars.ToArray());

        }
    }
}
