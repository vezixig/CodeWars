/*
https://www.codewars.com/kata/582cb0224e56e068d800003c
Nathan loves cycling.
Because Nathan knows it is important to stay hydrated, he drinks 0.5 litres of water per hour of cycling.
You get given the time in hours and you need to return the number of litres Nathan will drink, rounded to the smallest value.

For example:

time = 3 ----> litres = 1
time = 6.7---> litres = 3
time = 11.8--> litres = 5

What I learned: (int) floors the number, 
*/

namespace CodeWars.Kyu8
{
    internal class KeepHydrated
    {
        public const double LitersPerHour = 0.5;

        public static int CalculateLitresToDrink(double hours)
        {
            if (hours < 0 || hours > uint.MaxValue) throw new ArgumentOutOfRangeException(nameof(hours));
            return (int)(hours * LitersPerHour);
        }
    }

    [TestFixture]
    public class KeepHydratedTests
    {
        [Test]
        public static void Test1()
        {
            Assert.AreEqual(1, KeepHydrated.CalculateLitresToDrink(2));
        }

        [Test]
        public static void Test2()
        {
            Assert.AreEqual(0, KeepHydrated.CalculateLitresToDrink(1.4));
        }

        [Test]
        public static void Test3()
        {
            Assert.AreEqual(6, KeepHydrated.CalculateLitresToDrink(12.3));
        }

        [Test]
        public static void Test4()
        {
            Assert.AreEqual(0, KeepHydrated.CalculateLitresToDrink(0.82));
        }

        [Test]
        public static void Test5()
        {
            Assert.AreEqual(5, KeepHydrated.CalculateLitresToDrink(11.8));
        }

        [Test]
        public static void Test6()
        {
            Assert.AreEqual(893, KeepHydrated.CalculateLitresToDrink(1787));
        }

        [Test]
        public static void Test7()
        {
            Assert.AreEqual(0, KeepHydrated.CalculateLitresToDrink(0));
        }

        [Test]
        public static void TestOverflow()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => KeepHydrated.CalculateLitresToDrink((double)int.MaxValue * 2 + 2));
        }

        [Test]
        public static void TestNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => KeepHydrated.CalculateLitresToDrink((double)int.MaxValue * 2 + 2));
        }
    }
}