using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Tesla.q2
{
    public class DocumentProcessor : IDocumentProcessor
    {
        /// <summary>
        /// Analyzes the document and returns statistics.
        /// 
        /// 
        /// </summary>
        /// <exception cref="ArgumentNullException">document is null</exception>
        public Stats Analyze(string document)
        {
            if (document==null)
            {
                throw new ArgumentNullException();
            }

            var stats = new Stats();
            if (document.Trim().Length==0)
            {
                return stats;
            }
           var words= document.Split(' ');

            stats.NumberOfAllWords=words.Length;
            foreach (var word in words)
            {
                if (Regex.IsMatch(word, @"^\w+$"))
                {
                    stats.NumberOfAllWords++;
                }

                if (Regex.IsMatch(word, @"^\d+$"))
                { 
                    stats.NumberOfWordsThatContainOnlyDigits++;
                }
                else if (Regex.IsMatch(word, @"^[a-z]{1}.*$"))
                {
                    stats.NumberOfWordsStartingWithSmallLetter++;
                }
                else if (Regex.IsMatch(word, @"^[A-Z]{1}.*$"))
                {
                    stats.NumberOfWordsStartingWithCapitalLetter++;
                }

                if (string.IsNullOrWhiteSpace(stats.TheLongestWord)||word.Length> stats.TheLongestWord.Length)
                {
                    stats.TheLongestWord=word;
                }

                if (string.IsNullOrWhiteSpace(stats.TheShortestWord) || word.Length < stats.TheShortestWord.Length)
                {
                    stats.TheShortestWord = word;
                }
            }

            return stats;
        }
        /*
                 // Total number of words in the document
                public int NumberOfAllWords { get; set; }

                // Returns number of words that contain only digits, e.g. 13455, 98374
                public int NumberOfWordsThatContainOnlyDigits { get; set; }

                // Returns number of words that start with a lowercase letter, e.g. a, d, z
                public int NumberOfWordsStartingWithSmallLetter { get; set; }

                // Returns number of words that start with a capital letter, e.g. A, D, Z
                public int NumberOfWordsStartingWithCapitalLetter { get; set; }

                // Returns the longest word in the document
                public string TheLongestWord { get; set; }

                // Returns the shortest word in the document
                public string TheShortestWord { get; set; }
         */
    }
}
