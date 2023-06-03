/*
https://www.codewars.com/kata/55225023e1be1ec8bc000390
Jenny has written a function that returns a greeting for a user. However, she's in love with Johnny, and would like to greet him slightly different.
She added a special case to her function, but she made a mistake. Can you help her?
*/

namespace CodeWars.Kyu8
{
    internal class JennysSecretMessage
    {
        private const string LoversName = "Johnny";

        public static string greet(string name)
            => $"Hello, {(name == LoversName ? "my love" : name)}!";
    }

    [TestFixture]
    public class JennysGreeting
    {
        [Test]
        public static void ShouldGreetJimNormally()
        {
            Assert.AreEqual("Hello, Jim!", JennysSecretMessage.greet("Jim"));
        }

        [Test]
        public static void ShouldGreetJaneNormally()
        {
            Assert.AreEqual("Hello, Jane!", JennysSecretMessage.greet("Jane"));
        }

        [Test]
        public static void ShouldGreetSimonNormally()
        {
            Assert.AreEqual("Hello, Simon!", JennysSecretMessage.greet("Simon"));
        }

        [Test]
        public static void ShouldGreetJohnnySpecially()
        {
            Assert.AreEqual("Hello, my love!", JennysSecretMessage.greet("Johnny"));
        }
    }
}