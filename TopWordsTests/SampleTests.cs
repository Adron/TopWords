using TopWords;

namespace TopWordsTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void SampleTests()
    {
        Assert.That(TopTrioWords.TopTrio("a a a b c c d d d d e e e e e"), Is.EqualTo(new List<string> { "e", "d", "a" }));
        Assert.That(TopTrioWords.TopTrio("e e e e DDD ddd DdD: ddd ddd aa aA Aa, bb cc cC e e e"), Is.EqualTo(new List<string> { "e", "ddd", "aa" }));
        Assert.That(TopTrioWords.TopTrio(" //wont won't won't "), Is.EqualTo(new List<string> { "won't", "wont" }));
        Assert.That(TopTrioWords.TopTrio(" , e .. "), Is.EqualTo(new List<string> { "e" }));
        Assert.That(TopTrioWords.TopTrio(" ... "), Is.EqualTo(new List<string>()));
        Assert.That(TopTrioWords.TopTrio(" ' "), Is.EqualTo(new List<string>()));
        Assert.That(TopTrioWords.TopTrio(" ''' "), Is.EqualTo(new List<string>()));
        Assert.That(TopTrioWords.TopTrio(
            string.Join("\n", [
                "In a village of La Mancha, the name of which I have no desire to call to",
                "mind, there lived not long since one of those gentlemen that keep a lance",
                "in the lance-rack, an old buckler, a lean hack, and a greyhound for",
                "coursing. An olla of rather more beef than mutton, a salad on most",
                "nights, scraps on Saturdays, lentils on Fridays, and a pigeon or so extra",
                "on Sundays, made away with three-quarters of his income."
            ])), Is.EqualTo(new List<string> { "a", "of", "on" }));
    }
}