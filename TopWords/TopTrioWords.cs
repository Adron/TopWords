using System.Text.RegularExpressions;

namespace TopWords;

public static class TopTrioWords
{
    public static List<string> TopTrio(string s) =>
        Regex.Matches(s.ToLower(), @"[a-z']+")
            .Select(m => m.Value)
            .Where(word => word.Any(char.IsLetter))
            .GroupBy(word => word)
            .OrderByDescending(g => g.Count())
            .ThenBy(g => g.Key)
            .Take(3)
            .Select(g => g.Key)
            .ToList();
}