using System;
using System.Collections.Generic;
using SsWordCount.DataAccess.Entities;

namespace SsWordCount.Helpers
{
    public static class ConsoleHelper
    {
        public static void PrintWordsCount(IEnumerable<WordCount> wordsCount)
        {
            foreach (var wordCount in wordsCount)
            {
                Console.WriteLine($"{wordCount.Word} - {wordCount.Count}");
            }
        }

        public static string ReadLine(string message)
        {
            Console.WriteLine(message + ":");
            Console.Write(">");

            var line = Console.ReadLine();

            return line;
        }
    }
}