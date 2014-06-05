using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace skilleo.challenges
{
    public class TextAnalyticsChallenge : Challenge
    {
        /*
         *  Output string: Number of words, letters, symbols, words used more than once, letters used more than two times, words used once.
         *
         */

        public override string ProcessInput(string input)
        {
            var result = new StringBuilder();

            // Number of words
            var words = input.Split(' ').ToList();
            result.Append(words.Count);

            // Number of letters
            var letterCount = 0;
            words.ForEach(word => letterCount += word.Count(Char.IsLetter));
            result.Append(", " + letterCount);

            // Number of symbols (any non-letter and non-digit character, excluding white spaces)
            var symbolCount = 0;
            words.ForEach(word => symbolCount += word.Count(c => !Char.IsLetterOrDigit(c)));
            result.Append(", " + symbolCount);

            // Number of words used two or more times
            var repeatedWords = new Dictionary<string, int>();
            var repeatedLetters = new Dictionary<string, int>();

            // Get a list of characters that are symbols.
            var symbols = new List<char>();
            words.ForEach(word =>
            {
                foreach (var letter in word.Where(letter => !Char.IsLetterOrDigit(letter) && !symbols.Contains(letter)))
                {
                    symbols.Add(letter);
                }
            });

            // Calculate repeated words.
            foreach (var word in words)
            {
                // remove symbols from the word (", ', ., etc.)
                var wordWithoutSymbols = word;
                symbols.ForEach(symbol => { wordWithoutSymbols = wordWithoutSymbols.Replace(symbol.ToString(CultureInfo.InvariantCulture), ""); });

                if (!repeatedWords.ContainsKey(wordWithoutSymbols.ToLower()))
                {
                    repeatedWords.Add(wordWithoutSymbols.ToLower(), 1);
                    continue;
                }

                repeatedWords[wordWithoutSymbols.ToLower()] += 1;
            }

            // Calculate repeated letters.
            foreach (var word in words)
            {
                // remove symbols from the word (", ', ., etc.)
                var wordWithoutSymbols = word;
                symbols.ForEach(symbol => { wordWithoutSymbols = wordWithoutSymbols.Replace(symbol.ToString(CultureInfo.InvariantCulture), ""); });

                foreach (var letter in wordWithoutSymbols)
                {
                    if (!repeatedLetters.ContainsKey(letter.ToString(CultureInfo.InvariantCulture).ToLower()))
                    {
                        repeatedLetters.Add(letter.ToString(CultureInfo.InvariantCulture).ToLower(), 1);
                        continue;
                    }

                    repeatedLetters[letter.ToString(CultureInfo.InvariantCulture).ToLower()] += 1;
                }
            }

            result.Append(", " + repeatedWords.Count(word => word.Value > 1));

            // Number of letters used three or more times
            result.Append(", " + repeatedLetters.Count(letter => letter.Value >= 3));

            // Number of words only used once
            result.Append(", " + repeatedWords.Count(word => word.Value == 1));

            return result.ToString();
        }
    }
}
