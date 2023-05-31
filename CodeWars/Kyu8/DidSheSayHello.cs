using NUnit.Framework;

/*
https://www.codewars.com/kata/56a4addbfd4a55694100001f

You received a whatsup message from an unknown number. Could it be from that girl/boy with a foreign accent you met yesterday evening?
Write a simple function to check if the string contains the word hallo in different languages.
These are the languages of the possible people you met the night before:

    hello - english
    ciao - italian
    salut - french
    hallo - german
    hola - spanish
    ahoj - czech republic
    czesc - polish

Notes

    you can assume the input is a string.
    to keep this a beginner exercise you don't need to check if the greeting is a subset of word (Hallowen can pass the test)
    function should be case insensitive to pass the tests
*/

namespace CodeWars.Kyu8
{
    internal class DidSheSayHello
    {
        public static readonly string[] HelloTranslations = { "hello", "ciao", "salut", "hallo", "hola", "ahoj", "czesc" };

        public static bool Validate_hello(string greetings)
        {
            if (string.IsNullOrWhiteSpace(greetings)) return false;
            var loweredGreetings = greetings.ToLower();
            return HelloTranslations.Any(loweredGreetings.Contains);
        }
    }

    [TestFixture]
    public class DidSheSayHelloTests
    {
        [Test]
        public void Test1()
        {
            Assert.IsFalse(DidSheSayHello.Validate_hello(null));
            Assert.IsFalse(DidSheSayHello.Validate_hello(string.Empty));
            Assert.IsTrue(DidSheSayHello.Validate_hello("hello"));
            Assert.IsTrue(DidSheSayHello.Validate_hello("ciao bella!"));
            Assert.IsTrue(DidSheSayHello.Validate_hello("salut"));
            Assert.IsTrue(DidSheSayHello.Validate_hello("hallo, salut"));
            Assert.IsTrue(DidSheSayHello.Validate_hello("hombre! Hola!"));
            Assert.IsTrue(DidSheSayHello.Validate_hello("Hallo, wie geht\'s dir?"));
            Assert.IsTrue(DidSheSayHello.Validate_hello("AHOJ!"));
            Assert.IsTrue(DidSheSayHello.Validate_hello("czesc"));
            Assert.IsTrue(DidSheSayHello.Validate_hello("Ahoj"));
            Assert.IsFalse(DidSheSayHello.Validate_hello("meh"));
        }
    }
}