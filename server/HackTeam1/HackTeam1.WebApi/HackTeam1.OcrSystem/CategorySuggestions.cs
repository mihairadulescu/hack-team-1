using System;
using System.Collections.Generic;
using System.Linq;
using HackTeam1.Entities;

namespace HackTeam1.OcrSystem
{
    public class CategorySuggestions
    {
        private Dictionary<string, string[]> keywords = InitKeywords();

        private static Dictionary<string, string[]> InitKeywords()
        {
            var dict = new Dictionary<string, string[]>();
            dict.Add("Invoice", new[] { "invoice", "factura", "proforma", "receipt" });
            dict.Add("Contract", new[] { "contract" });
            dict.Add("Quote", new[] { "quote", "oferta" });

            return dict;
        }

        public string SuggestCategory(Document document)
        {
            var words = CountWords(document).ToArray();
            var scores = (
                from possibleCategory in keywords.Keys
                from wordOcc in words
                let score = keywords[possibleCategory].Count(x => x == wordOcc.Item1) * wordOcc.Item2
                group score by possibleCategory into g
                select new { category = g.Key, score = g.Sum() }
                ).ToArray();

            var maxScore = scores.Max(x => x.score);
            var score2 = scores.First(x => x.score == maxScore);

            return score2.category;
        }

        private static IEnumerable<Tuple<string, int>> CountWords(Document document)
        {
            var separators = new[] {"", ",", ":", "\\", "//", ".", "!", ";", "=", "\r\n", "\n", " ", "\t"};
            return document
                .Text
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLowerInvariant())
                .GroupBy(x => x)
                .Select(x => Tuple.Create(x.Key, x.Count()));
        }
    }
}