using System;
using System.Collections.Generic;
using SsWordCount.DataAccess.Entities;

namespace SsWordCount.Helpers
{
    public static class ConsoleHelper
    {
        /// <summary>
        /// Вывод списка слов на консоль
        /// </summary>
        /// <param name="wordsCount">Список со словами</param>
        public static void PrintWordsCount(IEnumerable<WordCount> wordsCount)
        {
            Console.WriteLine("\nКоличество слов:");
            foreach (var wordCount in wordsCount) Console.WriteLine($"{wordCount.Word} - {wordCount.Count}");
        }

        /// <summary>
        /// Метод считывания строки с консоли с выводом подсказки
        /// </summary>
        /// <param name="message">Подсказка</param>
        /// <returns>Считанная строка</returns>
        public static string ReadLine(string message)
        {
            Console.WriteLine(message + ":");
            Console.Write(">");

            var line = Console.ReadLine();

            return line;
        }
    }
}