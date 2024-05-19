using System.Text.RegularExpressions;

namespace TopWords;

public static class TopTrioWords
{
    public static List<string> Top3(string s)
    {
        // Remove all non-letter characters except apostrophes
        string cleanedText = Regex.Replace(s, "[^a-zA-Z']", " ");

        // Split the cleaned text into words
        string[] words = cleanedText.ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // Count the occurrences of each word
        Dictionary<string, int> wordCounts = new Dictionary<string, int>();
        foreach (string word in words)
        {
            if (string.IsNullOrWhiteSpace(word) || Regex.IsMatch(word, "^'+$"))
            {
                continue;
            }

            if (wordCounts.ContainsKey(word))
            {
                wordCounts[word]++;
            }
            else
            {
                wordCounts[word] = 1;
            }
        }

        // Get the top 3 words by occurrence count
        List<string> topWords = wordCounts
            .OrderByDescending(x => x.Value)
            .ThenBy(x => x.Key)
            .Take(3)
            .Select(x => x.Key)
            .ToList();

        return topWords;
    }
}