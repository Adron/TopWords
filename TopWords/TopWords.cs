using System.Text.RegularExpressions;

namespace TopWords;

public static class TopWords
{
    public static List<string> Top3(string s)
    {
        var cleanedText = Regex.Replace(s, "[^a-zA-Z']", " ");

        var words = cleanedText.ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var wordCounts = new Dictionary<string, int>();
        foreach (var word in words)
        {
            if (string.IsNullOrWhiteSpace(word) || Regex.IsMatch(word, "^'+$"))
            {
                continue;
            }

            if (!wordCounts.TryAdd(word, 1))
            {
                wordCounts[word]++;
            }
        }

        var topWords = wordCounts
            .OrderByDescending(x => x.Value)
            .ThenBy(x => x.Key)
            .Take(3)
            .Select(x => x.Key)
            .ToList();

        return topWords;
    }
}