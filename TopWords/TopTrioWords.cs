using System.Text.RegularExpressions;

namespace TopWords;

public static class TopTrioWords
{
    public static string[] Top3(string s)
    {
        return Regex.Matches(s.ToLower(), @"[a-z']+")
            .Cast<Match>()
            .Select(m => m.Value)
            .Where(word => !Regex.IsMatch(word, "^'+$"))
            .GroupBy(word => word)
            .OrderByDescending(g => g.Count())
            .ThenBy(g => g.Key)
            .Take(3)
            .Select(g => g.Key)
            .ToArray();
    }
}