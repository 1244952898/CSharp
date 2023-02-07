using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Tesla.q2
{
    public interface IDocumentProcessor
    {
        /// <summary>
        /// Analyzes the document and returns statistics.
        /// </summary>
        /// <exception cref="ArgumentNullException">document is null</exception>
        Stats Analyze(string document);

        private void Get()
        {
            Console.WriteLine(1111);
        }
    }
}
