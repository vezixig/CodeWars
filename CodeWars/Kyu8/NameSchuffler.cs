/*
https://www.codewars.com/kata/559ac78160f0be07c200005a
Write a function that returns a string in which firstname is swapped with last name.

Example(Input --> Output)
"john McClane" --> "McClane john"
*/

namespace CodeWars.Kyu8
{
    internal class NameSchuffler
    {
        public static string SchuffleName(string name)
            => string.IsNullOrEmpty(name)
            ? name
            : string.Join(" ", name.Split(' ').Reverse());
    }

    [TestFixture]
    public class NameSchufflerTests
    {
        [Test, Description("Sample Tests")]
        public void SampleTest()
        {
            Assert.AreEqual("McClane john", NameSchuffler.SchuffleName("john McClane"));
            Assert.AreEqual("jeggins Mary", NameSchuffler.SchuffleName("Mary jeggins"));
            Assert.AreEqual("jerry tom", NameSchuffler.SchuffleName("tom jerry"));
            Assert.AreEqual("jerry and tom", NameSchuffler.SchuffleName("tom and jerry"));
            Assert.AreEqual("tom", NameSchuffler.SchuffleName("tom"));
            Assert.AreEqual(null, NameSchuffler.SchuffleName(null));
            Assert.AreEqual("", NameSchuffler.SchuffleName(""));
        }
    }
}